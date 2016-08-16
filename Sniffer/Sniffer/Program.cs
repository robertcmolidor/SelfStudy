using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Sniffer
{
    class Program
    {
        static void Main(string[] args)
        {

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            IPAddress localIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
            


            listener.Bind(new IPEndPoint(localIP, 0));
            byte[] invalue = new byte[4] { 1, 0, 0, 0 };
            byte[] outvalue = new byte[4] { 1, 0, 0, 0 };
            listener.IOControl(IOControlCode.ReceiveAll, invalue, outvalue);
            while (true)
            {
                byte[] buffer = new byte[1000000];
                int read = listener.Receive(buffer);
                if (read >= 20)
                {
                    var toIp = new IPAddress((long) BitConverter.ToUInt32(buffer, 12));
                    var fromIp = new IPAddress((long) BitConverter.ToUInt32(buffer, 16));
                    var protocol = buffer[9];
                    var dataSize = buffer[2] << 8 | buffer[3];

                    if (fromIp.ToString() == "108.59.46.162" || toIp.ToString() == "108.59.46.162")
                    {
                        Console.WriteLine("Packet from {0} to {1}, protocol {2}, size {3}",
                            toIp,
                            fromIp,
                            protocol,
                            dataSize
                            );
                        
                        for (int i = 0; i < dataSize; i++)
                        {
                            Console.Write(String.Format("{0:X2} ", buffer[i]));
                        }
                        Console.WriteLine();
                        Console.WriteLine();


                    }
                }
            }
        }
    }
}
