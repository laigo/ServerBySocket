using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerBySocket
{
    public class SocketManager : ITransport
    {
        public Dictionary<string,SocketInfo> _listSocketInfo = null;
        private object lockListSockeInfoObj = new object();


        Socket _socket = null;
        EndPoint _endPoint = null;
        bool _isListening = false;
        int BACKLOG = 10;

        public delegate void OnConnectedHandler(string clientIP);
        public event OnConnectedHandler OnConnected;
        public delegate void OnReceiveMsgHandler(string ip);
        public event OnReceiveMsgHandler OnReceiveMsg;
        public event OnReceiveMsgHandler OnDisConnected;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public SocketManager(string ip, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //设置SOCKET允许多个SOCKET访问同一个本地IP地址和端口号 
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            IPAddress _ip = IPAddress.Parse(ip);
            _endPoint = new IPEndPoint(_ip, port);
            _listSocketInfo = new Dictionary<string, SocketInfo>();
        }


        public void Start()
        {
            try
            {
                _socket.Bind(_endPoint); //绑定端口
                _socket.Listen(BACKLOG); //开启监听
                Thread acceptServer = new Thread(AcceptWork); //开启新线程处理监听
                acceptServer.IsBackground = true;
                _isListening = true;
                acceptServer.Start();
            }

            catch (System.Exception ex)
            {
                return;
            }
        }
        public void Stop()
        {
            _isListening = false;

            Socket client = new Socket(
            AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(_endPoint);
                if (client.Connected)
                {
                    //当本机接收到1和2这两个字节时，就退出while循环
                    client.Send(new byte[] { (byte)1, (byte)2 });
                }
            }
            catch (SocketException se)
            {
                return;
            }
            finally
            {
                client.Close();
            }

            foreach (SocketInfo s in _listSocketInfo.Values)
            {
                s.isConnected = false;
                //s.socket.Close();
                //s.socket.Dispose();
            }
            _socket.Close();
        }
     

        public void AcceptWork()
        {
            while (_isListening)
            {
                //s.Accept();是一个同步方法. 就是一直要等到 客户端连接 才返回。不然一直处于等待状态。
                Socket acceptSocket = _socket.Accept();
                if (acceptSocket != null && this.OnConnected != null)
                {
                    SocketInfo sInfo = new SocketInfo();
                    sInfo.socket = acceptSocket;
                    lock (lockListSockeInfoObj)
                    { 
                        _listSocketInfo.Add(acceptSocket.RemoteEndPoint.ToString(), sInfo);
                    }                    
                    OnConnected(acceptSocket.RemoteEndPoint.ToString());
                    Thread socketConnectedThread = new Thread(newSocketReceive);
                    socketConnectedThread.IsBackground = true;
                    socketConnectedThread.Start(acceptSocket);
                }
                Thread.Sleep(200);
            }
        }

        public void newSocketReceive(object obj)
        {
            Socket socket = obj as Socket;
            SocketInfo sInfo = _listSocketInfo[socket.RemoteEndPoint.ToString()];
            sInfo.isConnected = true;
            while (sInfo.isConnected)
            {
                try
                {
                    if (sInfo.socket == null) return;
                    //这里向系统投递一个接收信息的请求，并为其指定ReceiveCallBack做为回调函数 
                    sInfo.socket.BeginReceive(sInfo.buffer, 0, sInfo.buffer.Length, SocketFlags.None, ReceiveCallBack, sInfo.socket.RemoteEndPoint);
                }
                catch (Exception ex)
                {
                    //return;
                    break;
                }
                Thread.Sleep(100);
            }
            if (this.OnDisConnected != null)
            { 
                OnDisConnected(sInfo.socket.RemoteEndPoint.ToString());
            }
            lock (lockListSockeInfoObj)
            { 
                _listSocketInfo.Remove(sInfo.socket.RemoteEndPoint.ToString());  
            }  
            sInfo.socket.Close();
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            EndPoint ep = ar.AsyncState as IPEndPoint;

            if (_listSocketInfo.Keys.Contains(ep.ToString()) == false)
            {
                return;
            }

            SocketInfo info = _listSocketInfo[ep.ToString()];
            int readCount = 0;
            try
            {
                if (info.socket == null) return;
                lock (lockListSockeInfoObj)
                {
                    readCount = info.socket.EndReceive(ar);//无法访问已释放的对象。todo? 
                }
            }

            catch (Exception ex)
            {                         
                /*
                SocketException exception
                if (exception.ErrorCode == 0x2746)
                {//远程主机强制关闭一个现有的连接 
                    ;//这里报错通信远程主机强迫关闭了一个现有的连接 然后就不能连接了
                }
                */

                info.isConnected = false;                
                return;
            }
            if (readCount > 0)
            {
                //byte[] buffer = new byte[readCount];
                //Buffer.BlockCopy(info.buffer, 0, buffer, 0, readCount);
                if (readCount < info.buffer.Length)
                {
                    byte[] newBuffer = new byte[readCount];
                    Buffer.BlockCopy(info.buffer, 0, newBuffer, 0, readCount);
                    info.msgBuffer = newBuffer;
                }
                else
                {
                    info.msgBuffer = info.buffer;
                }

                /*
                 modify qianf 2017.11.24 delete 不太明白下面代码的功能               
                string msgTip = Encoding.ASCII.GetString(info.msgBuffer);
                if (msgTip == "\0\0\0faild")
                {
                    info.isConnected = false;
                    if (this.OnDisConnected != null) OnDisConnected(info.socket.RemoteEndPoint.ToString());
                    _listSocketInfo.Remove(info.socket.RemoteEndPoint.ToString());
                    info.socket.Close();
                    return;
                }
                */

                if (OnReceiveMsg != null) OnReceiveMsg(info.socket.RemoteEndPoint.ToString());
            }
            else
            {
                info.isConnected = false;
            }
        }

        public void SendMsg(string text, string endPoint)
        {
            if (_listSocketInfo.Keys.Contains(endPoint) && _listSocketInfo[endPoint] != null)
            {
                _listSocketInfo[endPoint].socket.Send(Encoding.ASCII.GetBytes(text));
            }
        }
        public void SendMsg(byte[] pBuf,int index, UInt16 length, string endPoint)
        {
            try
            {
                if (_listSocketInfo.Keys.Contains(endPoint) && _listSocketInfo[endPoint] != null)
                {
                    _listSocketInfo[endPoint].socket.Send(pBuf, length, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public class SocketInfo
        {
            public Socket socket = null;
            public byte[] buffer = null;
            public byte[] msgBuffer = null;
            public bool isConnected = false;

            public SocketInfo()
            {
                buffer = new byte[1024 * 4];
            }
        }


        public  bool Tx(byte[] tx_buf, out string err_str)
        {
            err_str = "todo！";
            return false;
        }
    }
}
