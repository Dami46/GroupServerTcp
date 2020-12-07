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
        static UserHandler userHandler = new UserHandler();
        MessageReader messageReader;
        ClientComunicator comunicator;
        public delegate void TransmissionDataDelegate(NetworkStream stream);
        public User currentUser;

        public AsyncTcpServer(IPAddress IP, int port) : base(IP, port)
        {
            this.messageReader = new MessageReader();
            this.comunicator = new ClientComunicator();
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


        public bool Menu(NetworkStream stream, UserHandler userHandler)
        {
            comunicator.SendMessage(stream, messageReader.getMessage("menu"));
            var msg = comunicator.ReadResponse(stream);

            // rejestracja nowego uzytkownika
            if (msg == "2")
            {
                comunicator.SendMessage(stream, messageReader.getMessage("loginMessage"));
                string login = comunicator.ReadResponse(stream);

                comunicator.SendMessage(stream, messageReader.getMessage("passwordMessage"));
                string password = comunicator.ReadResponse(stream);

                comunicator.SendMessage(stream, messageReader.getMessage("permissionMessage"));
                int permission = Int32.Parse(comunicator.ReadResponse(stream));
                try
                {
                    userHandler.AddNewUser(login, password, permission);
                }
                catch
                {
                    comunicator.SendMessage(stream, messageReader.getMessage("wrongLoginMessage"));
                    return false;
                }
            }
            if (msg == "3")
            {
                comunicator.SendMessage(stream, messageReader.getMessage("removeMessage"));
                string login = comunicator.ReadResponse(stream);

                try
                {
                    userHandler.RemoveUser(login);
                }
                catch
                {
                    comunicator.SendMessage(stream, messageReader.getMessage("noLoginMessage"));
                    return false;
                }
            }
            return true;
        }

        protected override void BeginDataTransmission(NetworkStream stream)
        {
            UserHandler userHandler = new UserHandler();
            //userHandler.ShowUsers();
            var credentials = userHandler.UserList;

            while (true)
            {
                    byte[] msg = new byte[256];

                    bool go = false;
                    do
                    {
                        go = Menu(stream, userHandler);
                    } while (go == false);


                    comunicator.SendMessage(stream, messageReader.getMessage("loginMessage"));
                    string login = comunicator.ReadResponse(stream);

                    comunicator.SendMessage(stream, messageReader.getMessage("passwordMessage"));
                    string password = comunicator.ReadResponse(stream);

                    //Console.WriteLine("|" + login + "|" + password + "|");

                    if (userHandler.Login(login, password))
                    {
                        currentUser = userHandler.GetUser(login);
                        comunicator.SendMessage(stream, messageReader.getMessage("welcomeMessage"));

                        Game.guessingGame(stream, messageReader, comunicator, currentUser);
                        Console.WriteLine(currentUser.score);
                        userHandler.SaveUsersList();
                    }
                    else
                    {
                        comunicator.SendMessage(stream, messageReader.getMessage("refuseMessage"));
                    }

            }
        }
    }
}
