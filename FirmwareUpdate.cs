using QF;
using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerBySocket
{
    public class FirmwareUpdate : JT808
    {
        Thread ThreadTransBinFile;

        string FirmwareFilePath = null;
        
        Int32 TransFileRetryCnt=3, TransFileTimeOutMs=3000, TransFilePackageSize = 64;
        string TranDevType = null;
        string TranEndPoint = string.Empty;

        //
        public delegate void OnUpdateHandler(Int32 progressBarValue, Int32 progressBarMaximum, Int32 remainingTime);
        public event OnUpdateHandler OnTransFileInit;
        public event OnUpdateHandler OnTransFileIng;
        public event OnUpdateHandler OnTransFileOver;

        JT808 jt808 = new JT808();



        public FirmwareUpdate(string fileName, Int32 tryCnt, Int32 timeOutMs, Int32 packageSize, string devType,string endpoint)
        {
            FirmwareFilePath = fileName;
            //
            TransFileRetryCnt = tryCnt;
            TransFileTimeOutMs = timeOutMs;
            TransFilePackageSize = packageSize;
            TranEndPoint = endpoint;
            /*
             * 设备类型  设备型号   通讯协议编号
             *  X X X －  X X    － X X X
             */
            TranDevType = devType.Substring(0,3);

            //临时方案---JT-LFC数据包大小要求256, todo?
            int ret = string.Compare(TranDevType,"LFC");
            if (ret == 0)
            {
                TransFilePackageSize = 256;
            }
        }


        public void Start(DataDisHandler arg)
        {
            ThreadTransBinFile = new Thread(new ThreadStart(TransBinFile));
            ThreadTransBinFile.Priority = ThreadPriority.BelowNormal;
            ThreadTransBinFile.Start();
            jt808.DataDis += arg;
        }

        public void Stop()
        {
            //FirmwareUpdateBtn.Text = "开始";

            //MessageBox.Show("Thread_TransBinFile End!!!");
            ThreadTransBinFile.Abort();
        }


        private void TransBinFile()
        {
            using (FileStream fs = new FileStream(FirmwareFilePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                {
                    jt808.TCPSent += Transmission.SocketSent;
                    jt808.UARTSent += Transmission.UartSent;
                    
                    Int32 length = Convert.ToInt32(br.BaseStream.Length);

                    UInt16 TotalNO = Convert.ToUInt16(length / TransFilePackageSize);
                    if (length % TransFilePackageSize != 0)
                    {
                        TotalNO += 1;
                    }
                    /*BIN读取*/
                    byte[] chunk = br.ReadBytes(length);
                  
                    //固件升级0x8FFF
                    jt808.message_head.id = MsgID.MSG_FIRMWARE_UPGRADE;

                    //
                    TotalNO += 2;

                    UInt16 packageno = 0;
                    for (packageno = 0; packageno < TotalNO ; packageno++)
                    {/*0 COH   +1 EOT*/
                    
                        //消息体
                        byte[] msgbody = new byte[1024];
                        int oft = 0;                        
                        
                        //设备类型	3BYTE -ASCII码，参照《登录报文设备型号命名规则》中定义
                        byte[] tempChar = Encoding.ASCII.GetBytes(TranDevType); 
                        Array.Copy(tempChar, 0, msgbody, oft, 3);
                        oft += 3;

                        //总包数	WORD
                        Bytes.FromUInt16(TotalNO, msgbody, oft);
                        oft += 2;//--WORD 包序号	
                    
                        //包序号	WORD---从1开始
                        Bytes.FromUInt16((ushort)(packageno + 1), msgbody, oft);
                        oft += 2;//--WORD 包序号

                        //数据体长度
                        Bytes.FromUInt16((ushort)TransFilePackageSize, msgbody, oft);
                        oft += 2;//--WORD 数据体长度

                        //-包数据体
                        byte[] arrPckData = new byte[TransFilePackageSize];
                            
                        //数据体长度WORD-N= 128 * Q (Q: 分包倍率，见表A4.1)
                        for (UInt16 i = 0; i < TransFilePackageSize; i++)
                        {
                            Int32 shift = packageno  * TransFilePackageSize + i;

                            if (shift >= chunk.Length)
                            {
                                arrPckData[i] = DLT645.DUMP;
                            }
                            else
                            {
                                arrPckData[i] = chunk[shift];
                            }
                        }

                        arrPckData.CopyTo(msgbody, oft);
                        oft += TransFilePackageSize;
                        
                        //消息体长度
                        jt808.message_head.msgLengthBit0_9 = (UInt16)oft;



                        sn_pond.Clear();

                        /*报文发送 + 重试*/
                        for (Int32 tryNO = 0; tryNO < TransFileRetryCnt; tryNO++)
                        {
                            autoResetEvent.WaitOne(1);

                            sn_pond.Add(PlatDownSerialNum);

                            jt808.PackageFrame(MsgID.MSG_FIRMWARE_UPGRADE, msgbody, 0, false, TranEndPoint);
                            //System.Threading.Thread.CurrentThread.Abort();

                            bool re = autoResetEvent.WaitOne(TransFileTimeOutMs);
                            if (re)
                            {
                                Thread.Sleep(1);
                                break;
                            }
                        }
                        Int32 remainingTime = (TotalNO - packageno-1) * TransFileTimeOutMs * TransFileRetryCnt;

                        //升级进度
                        if (OnTransFileIng != null)
                        {
                            OnTransFileIng(packageno+1,TotalNO, remainingTime/1000);
                        }
                    }
                }
            }

            //升级完成
            if (OnTransFileOver != null)
            {
                OnTransFileOver(1, 1, 0);
            }

        }
    }
}
