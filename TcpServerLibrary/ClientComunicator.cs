using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServerLibrary
{
    public class ClientComunicator
    {
        public string ReadResponse(NetworkStream stream)
        {
            byte[] response = new byte[256];

            try
            {
                do
                {
                    stream.Read(response, 0, response.Length);

                } while (Encoding.UTF8.GetString(response).Replace("\0", "") == "\r\n" || Encoding.UTF8.GetString(response).Replace("\0", "") == "\n");
            }
            catch
            {

            }
            return Encoding.UTF8.GetString(response).Replace("\0", "").Replace("\n", "");
        }

        public void SendMessage(NetworkStream stream, string message)
        {
            byte[] messageBytes = new ASCIIEncoding().GetBytes(message);
            try
            {
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
            catch
            {

            }
        }
    }

}