using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;
using log4net;

namespace NetworkStudy
{
    public class ICMPCheck
    {
        private static ManualResetEvent gotMessage;
        private static IPAddress ipAddress;
        private static IntPtr stateHandle; // Dont know what it is for, or what to do with it
        private static Disposables.StateObject so = null;
        private static Socket icmpClient;
        private static EndPoint remoteRawEndPoint = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
        public static Queue<byte[]> m_icmpQueue = new Queue<byte[]>();
        public static object m_syncLock = new object();
        private static IPEndPoint NIC = null;
        private static int Queued = 0;
        private static int DeQueued = 0;
        private static int CallCount = 0;
        public static IAsyncResult iar;

        public static void Start()
        {
            try
            {
                using (icmpClient = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp))
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                    IPHostEntry hostInfo = Dns.Resolve(Dns.GetHostName());
                    IPAddress[] address = hostInfo.AddressList;
                    ipAddress = address[0];
                    NIC = new IPEndPoint(ipAddress, 0);
                    icmpClient.Bind(NIC); // Bind to localhost, port any
                    byte[] inBytes = new byte[] { 1, 0, 0, 0 };
                    byte[] outBytes = new byte[] { 0, 0, 0, 0 };
                    icmpClient.IOControl(IOControlCode.ReceiveAll, inBytes, outBytes); //only outgoing packets
                    icmpClient.ReceiveBufferSize = 1024;

                    while (true)
                    {
                        //gotMessage = new ManualResetEvent(false);
                        using (so = new Disposables.StateObject(stateHandle))
                        {

                            so.workSocket = icmpClient;

                            iar = icmpClient.BeginReceiveFrom(so.buffer, 0, Disposables.StateObject.BUFFER_SIZE, 0, ref remoteRawEndPoint, new AsyncCallback(ReceiveFromCallback), so); //blocking

                            iar.AsyncWaitHandle.WaitOne(); //gotMessage.WaitOne(); //iar.AsyncWaitHandle.WaitOne(); // seems to be unreliable

                            for (int i = DeQueued; i < Queued; i++)
                            {
                                //DequeueParse.DequeueAndParse(ref so);
                                Interlocked.Increment(ref DeQueued);
                                ICMPProgram.logger.Debug("ICMPCheck-0: Signal + Message received: " + remoteRawEndPoint.ToString() + " Queue: " + m_icmpQueue.Count.ToString() + " " + Queued.ToString() + " " + DeQueued.ToString());
                            }
                        } // using StateObject
                        //gotMessage.Dispose();
                    }// while
                }//using Socket
            } // try
            catch (Exception excp)
            {
                ICMPProgram.logger.Error("ICMPCheck: Exception Mainblock. " + excp.Message);
            }
            return;
        }

        private static void ReceiveFromCallback(IAsyncResult iar)
        {
            Interlocked.Increment(ref CallCount);
            try
            {
                if (ICMPProgram.stopRequest) return;
                Disposables.StateObject state = (Disposables.StateObject)iar.AsyncState;
                Socket client = ((Disposables.StateObject)iar.AsyncState).workSocket;
                EndPoint tempRemoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);

                int bytesRead = client.EndReceiveFrom(iar, ref tempRemoteEP);

                if (bytesRead > 0)
                {
                    if (!(((IPEndPoint)tempRemoteEP).Address).Equals(NIC.Address)) // ignore messages from local host
                    {
                        byte[] _icmpData = new byte[bytesRead];
                        byte[] icmpType = new byte[1];
                        Buffer.BlockCopy(state.buffer, 20, icmpType, 0, 1);

                        //if (((int)icmpType[0] == 3)) // only type 3
                        if (true) // all tyoes for now
                        {
                            Buffer.BlockCopy(state.buffer, 0, _icmpData, 0, bytesRead);
                            lock (m_syncLock)
                            {
                                m_icmpQueue.Enqueue(_icmpData);
                                Interlocked.Increment(ref Queued);
                            }
                        }
                        // the next callback is required when using AsyncWaitHandle.WaitOne signaling, not required (but useful for high volume) for ManualResetEvents
                        client.BeginReceiveFrom(state.buffer, 0, Disposables.StateObject.BUFFER_SIZE, 0, ref tempRemoteEP, new AsyncCallback(ReceiveFromCallback), state); // suitable for high volume
                        remoteRawEndPoint = tempRemoteEP;
                        //ICMPProgram.logger.Debug("ICMPCheck: Bytes: " + bytesRead.ToString() + ", Type: " + icmpType[0].ToString() + " " + tempRemoteEP.ToString() + " " + m_icmpQueue.Count.ToString() + " " + Queued.ToString() + " " + CallCount.ToString() + " " + iar.IsCompleted.ToString());
                    }
                }
                else
                {
                    ICMPProgram.logger.Debug("ICMPCheck: bytesRead = 0 ");
                }
            }
            catch (Exception excp)
            {
                ICMPProgram.logger.Debug("ICMPCheck:ReceiveFromCallback main " + excp.Message);
            }
            finally
            {
                //gotMessage.Set();
            }
        }
    }
}