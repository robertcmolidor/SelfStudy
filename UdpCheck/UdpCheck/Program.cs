using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpCheck
{
    class Program
    {
        private const int listenPort = 11000;
        public static bool MessageReceived = false;
        static void Main(string[] args)
        {

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("108.59.46.162");
            byte[] sendbuf = Encoding.ASCII.GetBytes("ASDSAadkasj");
            IPEndPoint ep = new IPEndPoint(broadcast, 17);
            s.SendTo(sendbuf, ep);
            Console.WriteLine("Message sent to the broadcast address");
            int timeOut = 10;
            int timeOutCounter = 0;


            while ((!MessageReceived) || timeOutCounter < timeOut)
            {
                Console.WriteLine("Waiting For Message");
                timeOutCounter++;
                Thread.Sleep(1000);
            }

        }

        private static void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool done = false;

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",groupEP.ToString(),Encoding.ASCII.GetString(bytes, 0, bytes.Length));


                    MessageReceived = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

    }
}
