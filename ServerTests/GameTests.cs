using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpServerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary;

namespace ServerLibrary.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameWorks()
        {
            try
            {
                Game game = new Game();
                Type type = typeof(Game);
                Assert.IsInstanceOfType(game, type);
                if (game.numberValue > 100 || game.numberValue < 0)
                {
                    Assert.Fail();
                }
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
          
        }

        [TestMethod()]
        public void hotOrNotGameWorks()
        {
            Game game = new Game();
            String result = game.hotOrNot(4);
            Console.WriteLine(result);
            String.IsNullOrEmpty(result);
        }
    }
}