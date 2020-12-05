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
    public class MessageReaderTests
    {
        [TestMethod()]
        public void MessageReaderTest()
        {
            try
            {
                Assert.IsTrue(File.Exists("Messages.conf"));
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void getMessageTest()
        {
            MessageReader messageReader = new MessageReader();
            try
            {
                messageReader.getMessage("guessMessage");
                messageReader.getMessage("loginMessage");
                messageReader.getMessage("winningMessage");
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void getMessageTest2()
        {
            MessageReader messageReader = new MessageReader();
            String value = messageReader.getMessage("guessMessage");
            String key = "Podaj login:";
            value.Contains(key);
            Assert.IsNotNull(value);
        }
    }
}