using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public class UserHandler
    {
        private readonly string path = "usersCredentials";
        private List<User> userList;

        public List<User> UserList { get => userList; set => userList = value; }

        public UserHandler() {
            ReadUsersCredentials();
        }

        // Sprawdza czy dany user jest na liście, jeśli tak to go dodaje (Whitelista)
        public void AddNewUser(string login, string password, int permission)
        {
            User user = new User(login, password, permission);
            UserList.Add(user);
            StreamWriter file = File.AppendText("usersCredentials");
            file.Write( "\r\n" + user.login + ";" + user.password + ";" + user.permission.ToString() + ";" + user.score.ToString());
            file.Close();
        }

        public void AddNewUser(User user)
        {
            UserList.Add(user);
            StreamWriter file = File.AppendText("usersCredentials");
            file.Write("\r\n" +  user.login + ";" + user.password + ";" + user.permission.ToString() + ";" + user.score.ToString());
            file.Close();
        }

        public void ReadUsersCredentials()
        {
            string line;
            this.UserList = new List<User>();
            StreamReader file = new StreamReader("usersCredentials");
            while ((line = file.ReadLine()) != null)
            {
                var cred = line.Split(';');
                User user = new User(cred[0], cred[1], Int32.Parse(cred[2]), Int32.Parse(cred[3]));
                UserList.Add(user);
            }
            file.Close();
        }

        // Wyświetlenie na konsoli wszystkich użytkowników 
        public void ShowUsers()
        {
            Console.WriteLine("Current users: ");
            foreach (var user in UserList)
            {
                Console.WriteLine("Login: " + user.login + " Password: " + user.password + " Permissions: " + user.permission.ToString() + "Score: " + user.score.ToString());
            }
        }
        public StringBuilder ShowUsersRanking()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Users Ranking: " + "\r\n");
            foreach (var user in UserList)
            {
                stringBuilder.Append("Login: " + user.login + "Score: " + user.score.ToString() + "\r\n");
            }
            return stringBuilder;
        }

        public void SaveUsersList()
        {
            File.WriteAllText(path, String.Empty);
            StreamWriter file = File.AppendText("usersCredentials");
            foreach (var user in UserList)
            {
                file.WriteLine(user.login + ";" + user.password + ";" + user.permission.ToString() + ";" + user.score.ToString());
            }
            file.Close();
        }

        public User GetUser (String login)
        {  
            foreach (User user in UserList)
            {
                if(login == user.login)
                {
                    return user;
                }
            }
            return new User("", "", 0);
        }

        //Usuwanie usera z listy 
        public void RemoveUser(string login)
        {
            User user = GetUser(login);
            if (user.login != "" || user.login != "admin")
            {
                List<string> linesToKeep = new List<string> { };
                using (StreamReader sr = File.OpenText("usersCredentials"))
                {
                    foreach (var us in UserList.ToList())
                    {
                        if (us.login == login)
                        {
                            UserList.Remove(us);
                        }
                    }

                }
                SaveUsersList();
            }
            else
            {
                throw new Exception();
            }
        }

        public bool Login(string login, string password)
        {
            foreach (var user in UserList)
            {
                if (user.login == login)
                {
                    if (user.password == password)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
