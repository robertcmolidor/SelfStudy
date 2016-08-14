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

            var ipString = "";

            SendUdp(11000, "192.168.2.255", 11000, Encoding.ASCII.GetBytes("Hello!"));

            CreateIcmpSocket();
            while (true) { Thread.Sleep(10); }











        }
        private static void CreateIcmpSocket()
        {
            icmpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
            icmpSocket.Bind(new IPEndPoint(IPAddress.Any, 0));
            // Uncomment to receive all ICMP message (including destination unreachable).
            // Requires that the socket is bound to a particular interface. With mono,
            // fails on any OS but Windows.
            //if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            //{
                icmpSocket.IOControl(IOControlCode.ReceiveAll, new byte[] { 1, 0, 0, 0 }, new byte[] { 1, 0, 0, 0 });
            //}
            BeginReceiveFrom();
        }
        private static void ReceiveCallback(IAsyncResult ar)
        {
            int len = icmpSocket.EndReceiveFrom(ar, ref remoteEndPoint);
            Console.WriteLine(string.Format("{0} Received {1} bytes from {2}",
                DateTime.Now, len, remoteEndPoint));
            LogIcmp(receiveBuffer, len);
            BeginReceiveFrom();
        }
        private static void BeginReceiveFrom()
        {
            icmpSocket.BeginReceiveFrom(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ref remoteEndPoint, ReceiveCallback, null);
        }
        private static void LogIcmp(byte[] buffer, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(String.Format("{0:X2} ", buffer[i]));
            }
            Console.WriteLine("");
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
