using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary;

namespace TcpServerLibrary
{
    public class TcpMenu
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
                    comunicator.SendMessage(stream, "ADM");
                    AdminMenu(stream);
                }
                else if (loggedUser.permission == 1)
                {
                    comunicator.SendMessage(stream, "USR");
                    UserMenu(stream);
                }
            } while (Continue_session == true);
        }

        public bool LoginMenu(NetworkStream stream)
        {
            //comunicator.SendMessage(stream, messageReader.getMessage("loginMenu"));
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
            // comunicator.SendMessage(stream, messageReader.getMessage("loginMessage"));
            var credentials = comunicator.ReadResponse(stream);
            var credits = credentials.Split(';');
            string login = credits[0];
            //comunicator.SendMessage(stream, messageReader.getMessage("passwordMessage"));
            string password = credits[1];
            if (userHandler.Login(login, password))
            {
                loggedUser = userHandler.GetUser(login);
                comunicator.SendMessage(stream, "ACK");
                return true;
            }
            else
            {
                comunicator.SendMessage(stream, "DEC");
                return false;
            }
        }


        private void RegiserUser(NetworkStream stream)
        {
            comunicator.SendMessage(stream, messageReader.getMessage("loginMessage"));
            string login = comunicator.ReadResponse(stream);

            comunicator.SendMessage(stream, messageReader.getMessage("passwordMessage"));
            string password = comunicator.ReadResponse(stream);
            while (!CheckPassword(password))
            {
                comunicator.SendMessage(stream, messageReader.getMessage("badPasswordMessage"));
                password = comunicator.ReadResponse(stream);
            }

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

        private static bool CheckPassword(string password)
        {
            if (password.Length < 6 || password.Length > 20)
            {
                return false;
            }

            if (password.Contains(" "))
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                return false;
            }

            if (!password.Any(char.IsNumber))
            {
                return false;
            }
            return true;
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

        private void ReadUserList(NetworkStream stream)
        {
            comunicator.SendMessage(stream, userHandler.ShowUsersRanking().ToString());
        }

        private void ChangePassword(NetworkStream stream)
        {
            LoginUser(stream);
            comunicator.SendMessage(stream, messageReader.getMessage("newPasswordMessage"));
            string password = comunicator.ReadResponse(stream);
            while (!CheckPassword(password))
            {
                comunicator.SendMessage(stream, messageReader.getMessage("badPasswordMessage"));
                password = comunicator.ReadResponse(stream);
            }
            userHandler.RemoveUser(loggedUser.login);
            userHandler.AddNewUser(loggedUser.login, password, 1);
        }

        public void UserMenu(NetworkStream stream)
        {
            //comunicator.SendMessage(stream, messageReader.getMessage("userMenu"));
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
                        ReadUserList(stream);
                        break;
                    }
                case "3":
                    {
                        ChangePassword(stream);
                        break;
                    }
                case "4":
                    {
                        Continue_session = false;
                        break;
                    }
            }

        }

        public void AdminMenu(NetworkStream stream)
        {
            //comunicator.SendMessage(stream, messageReader.getMessage("adminMenu"));
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
                        ReadUserList(stream);
                        break;
                    }
                case "5":
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
