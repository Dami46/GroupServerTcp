using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public class ClientTCP
    {
        private IPAddress ipAddress;
        private int port;

        public ClientTCP(IPAddress ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public string ReadResponse(NetworkStream stream)
        {
            byte[] response = new byte[256];
            do
            {
                stream.Read(response, 0, response.Length);
            } while (Encoding.UTF8.GetString(response).Replace("\0", "") == "\r\n");
            return Encoding.UTF8.GetString(response).Replace("\0", "");
        }

        public void SendMessage(NetworkStream stream, string message)
        {
            byte[] messageBytes = new ASCIIEncoding().GetBytes(message);
            stream.Write(messageBytes, 0, messageBytes.Length);
        }

        public void Start()
        {
            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);
            NetworkStream stream = client.GetStream();

            while (true)
            {
                string response = ReadResponse(stream);
                Console.WriteLine(response);
                if (response == " Zalogowano " || response == " Nieprawidlowy login lub haslo " )
                {
                    response = ReadResponse(stream);
                    Console.WriteLine(response);
                }
                string input = Console.ReadLine();
                SendMessage(stream, input);
            }

        }
    }
}
