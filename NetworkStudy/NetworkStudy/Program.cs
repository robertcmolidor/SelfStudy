using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace NetworkStudy
{
    class Program
    {
        private static Socket icmpSocket;
        private static byte[] receiveBuffer = new byte[256];
        private static EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        static void Main(string[] args)
        {

            
            var icmpListener = new Thread(new ThreadStart(IcmpListener));
            icmpListener.Start();
            SendUdp(5050, "216.58.218.142",80,new byte[1024]);
            Thread.Sleep(1000);



            
            icmpListener.Abort();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();


        }

        static void IcmpListener()
        {
            while (true)
            {

                Socket icmpListener = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                icmpListener.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.6"), 0));
                icmpListener.IOControl(IOControlCode.ReceiveAll, new byte[] { 1, 0, 0, 0 }, null);

                byte[] buffer = new byte[1024 * 1024];
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                int bytesRead = icmpListener.ReceiveFrom(buffer, ref remoteEndPoint);
                string receivedMsg = Encoding.UTF8.GetString(buffer, 28, bytesRead);
                Console.WriteLine(DateTime.Now.ToString() + ": Received " + bytesRead + "B from " + remoteEndPoint +
                                  ": " + receivedMsg);
            }
        }

        static void SendUdp(int srcPort, string dstIp, int dstPort, byte[] data)
        {
            using (UdpClient c = new UdpClient(srcPort))
                c.Send(data, data.Length, dstIp, dstPort);
        }

        //public void IcmpWait(string ip)
        //{
        //    Console.WriteLine("Listening for response");
        //    Socket icmpListener = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
        //    icmpListener.Bind(new IPEndPoint(IPAddress.Parse("10.1.1.2"), 0));
        //    icmpListener.IOControl(IOControlCode.ReceiveAll, new byte[] { 1, 0, 0, 0 }, new byte[] { 1, 0, 0, 0 });

        //    byte[] buffer = new byte[4096];
        //    EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        //    int bytesRead = icmpListener.ReceiveFrom(buffer, ref remoteEndPoint);
        //    Console.WriteLine("ICMPListener received " + bytesRead + " from " + remoteEndPoint);
        //    Console.ReadLine();
        //}
    }
}
