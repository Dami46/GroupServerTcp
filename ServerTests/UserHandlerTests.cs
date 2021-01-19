using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Tests
{
    [TestClass()]
    public class UserHandlerTests
    {

        UserHandler userHandler = new UserHandler();

        [TestMethod()]
        public void UserHandlerTest()
        {
            try
            {
                User user = userHandler.UserList.First();
                Assert.AreEqual(user.login, "admin");
                Assert.AreEqual(user.password,"admin");
                Assert.AreEqual(user.permission,0);
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        public void AddNewUserTest()
        {
            try
            {
                string login = "adduser";
                string password = "withlogin";
                int i = 0;
                while(userHandler.Login(login, password))
                {
                    login = "adduser" + i;
                    i++;
                }
                userHandler.AddNewUser(new User(login, password, 1));
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddNewUserTest1()
        {
            string login = "adduser";
            string password = "withlogin";
            int i = 0;
            while (userHandler.Login(login, password))
            {
                login = "adduser" + i;
                i++;
            }
            userHandler.AddNewUser(login, password, 1);
        }

        [TestMethod()]
        public void ReadUsersCredentialsTest()
        {
            try
            {
                Assert.IsTrue(File.Exists("usersCredentials"));
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ShowUsersTest()
        {
            CollectionAssert.AllItemsAreNotNull(userHandler.UserList);
        }

        [TestMethod()]
        public void ShowUsersRankingTest()
        {
            StringBuilder stringBuilder = userHandler.ShowUsersRanking();
            Assert.IsNotNull(stringBuilder);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            User user = new User("admin", "admin", 0);
            User user2 = userHandler.GetUser("admin");
            Assert.ReferenceEquals(user, user2);
        }


        [TestMethod()]
        public void LoginTest()
        {
            bool result = userHandler.Login("admin", "admin");
            Assert.IsTrue(result);
        }
    }
}