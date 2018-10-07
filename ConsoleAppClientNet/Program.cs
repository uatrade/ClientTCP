using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleAppClientNet
{
    class Program
    {
        static int port = 777;
        static string adress= "10.10.6.10";
        static void Main(string[] args)
        {
          IPAddress ip = IPAddress.Parse(adress);
          IPEndPoint ep = new IPEndPoint(ip, port);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

          
                
                s.Connect(ep);
                Console.WriteLine("Введите сообщение");

  
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);

                if(s.Connected)
                {
                    s.Send(data);

                    StringBuilder bilder = new StringBuilder();
                    byte[] buffer = new byte[1024];

                    int bytes = 0;

                    do
                    {
                        bytes = s.Receive(buffer);
                        bilder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));


                    } while (bytes > 0);
                    Console.WriteLine($"Ответ: {bilder.ToString()}");

                }


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
