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
        [TestMethod()]
        public void UserHandlerTest()
        {
            try
            {
                UserHandler userHandler = new UserHandler(); 
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
                UserHandler userHandler = new UserHandler();
                userHandler.AddNewUser(new User("adduser", "withlogin", 1));
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddNewUserTest1()
        {
            UserHandler userHandler = new UserHandler();
            userHandler.AddNewUser("adduser", "withuser", 1);
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
            UserHandler userHandler = new UserHandler();
            CollectionAssert.AllItemsAreNotNull(userHandler.UserList);
        }

        [TestMethod()]
        public void ShowUsersRankingTest()
        {
            UserHandler userHandler = new UserHandler();
            StringBuilder stringBuilder = userHandler.ShowUsersRanking();
            Assert.IsNotNull(stringBuilder);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            UserHandler userHandler = new UserHandler();
            User user = new User("admin", "admin", 0);
            User user2 = userHandler.GetUser("admin");
            Assert.ReferenceEquals(user, user2);
        }


        [TestMethod()]
        public void LoginTest()
        {
            UserHandler userHandler = new UserHandler();
            bool result = userHandler.Login("admin", "admin");
            Assert.IsTrue(result);
        }
    }
}