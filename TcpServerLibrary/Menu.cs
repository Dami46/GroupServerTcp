using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary;

namespace TcpServerLibrary
{
    class Menu
    {
        protected User loggedUser;
        private static UserHandler userHandler = new UserHandler();
        ClientComunicator comunicator = new ClientComunicator();
        MessageReader messageReader = new MessageReader();
        public User LoggedUser => loggedUser;

        protected bool Continue_session { get => continue_session; set => continue_session = value; }

        private bool continue_session = true;

        public void ShowMenu(NetworkStream stream)
        {
            do
            {
                if (loggedUser.permission == 0)
                {
                    AdminMenu(stream);
                }
                else if (loggedUser.permission == 1)
                {
                    UserMenu(stream);
                }
            } while (Continue_session == true);
        }

        public bool LoginMenu(NetworkStream stream)
        {
            comunicator.SendMessage(stream, messageReader.getMessage("loginMenu"));
            var msg = comunicator.ReadResponse(stream);
            switch (msg)
            {
                case "1":
                    {
                        return LoginUser(stream);
                    }
                case "2":
                    {
                        RegiserUser(stream);
                        return false;
                    }
                default:
                    return false;
            }
        }

        private bool LoginUser(NetworkStream stream)
        {
            comunicator.SendMessage(stream, messageReader.getMessage("loginMessage"));
            string login = comunicator.ReadResponse(stream);

            comunicator.SendMessage(stream, messageReader.getMessage("passwordMessage"));
            string password = comunicator.ReadResponse(stream);
            if (userHandler.Login(login, password))
            {
                loggedUser = userHandler.GetUser(login);
                return true;
            }
            else
                return false;
        }

        private void RegiserUser(NetworkStream stream)
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
            }
        }

        private void RemoveUser(NetworkStream stream)
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
            }
        }

        private void StartGame(NetworkStream stream)
        {
            Game.guessingGame(stream, messageReader, comunicator, LoggedUser);
            userHandler.SaveUsersList();
        }

        public void UserMenu(NetworkStream stream)
        {
            comunicator.SendMessage(stream, messageReader.getMessage("userMenu"));
            var msg = comunicator.ReadResponse(stream);
            switch (msg)
            {
                case "1":
                    {
                        StartGame(stream);
                        break;
                    }
                case "2":
                    {
                        Continue_session = false;
                        break;
                    }
            }

        }

        public void AdminMenu(NetworkStream stream)
        {
            comunicator.SendMessage(stream, messageReader.getMessage("adminMenu"));
            var msg = comunicator.ReadResponse(stream);
            switch (msg)
            {
                case "1":
                    {
                        StartGame(stream);
                        break;
                    }
                case "2":
                    {
                        RegiserUser(stream);
                        break;
                    }
                case "3":
                    {
                        RemoveUser(stream);
                        break;
                    }
                case "4":
                    {
                        Continue_session = false;
                        break;
                    }
                default:
                    {
                        Continue_session = true;
                        break;
                    }


            }
        }

    }
}
