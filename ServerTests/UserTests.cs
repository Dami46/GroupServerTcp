using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserCreate()
        {
            User user = new User("", "", 1);
            Assert.IsNotNull(user);
        }

        [TestMethod()]
        public void UserCreate1()
        {
            User user = new User("DAMI", "DAMI", 1, 2323);
            Assert.IsNotNull(user);
        }

        [TestMethod()]
        public void UserCreate2()
        {
            Type type = typeof(User);
            User user = new User("DAMI", "DAMI", 1, 2323);
            Assert.IsInstanceOfType(user, type);
        }

        [TestMethod()]
        public void UserPermision()
        {
            User user = new User("", "", 4);
            Assert.AreEqual(1, user.permission);
        }

    }
}