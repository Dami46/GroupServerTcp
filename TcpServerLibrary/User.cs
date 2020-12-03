using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public class User
    {
        public string login;
        public string password;
        public int permission;
        public int score;

        public User(string login, string password, int permission, int score)
        {
            this.login = login;
            this.password = password;
            this.permission = permission;
            this.score = score;
        }
        public User(string login, string password, int permission)
        {
            this.login = login;
            this.password = password;
            this.permission = permission;
            this.score = 0;
        }
    }
}
