using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TcpServerLibrary;

namespace ServerLibrary
{
    public class AsyncTcpServer : AbstractServer
    {
        public delegate void TransmissionDataDelegate(NetworkStream stream);

        public AsyncTcpServer(IPAddress IP, int port) : base(IP, port)
        {
        }

        protected override void AcceptClient()
        {
            while (true)
            {
                tcpClient = TcpListener.AcceptTcpClient();
                networkStream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                transmissionDelegate.BeginInvoke(networkStream, TransmissionCallback, tcpClient);
                Console.WriteLine("Client connected");
            }
        }

        private void TransmissionCallback(IAsyncResult ar)
        {
            tcpClient.Close();
        }

        public override void Start()
        {
            StartListening();
            AcceptClient();
        }

        protected override void BeginDataTransmission(NetworkStream stream)
        {
            TcpMenu menu = new TcpMenu();
            while (true)
            {
                while (menu.LoginMenu(stream))
                {
                    menu.ShowMenu(stream);
                }
            }
        }
    }
}
