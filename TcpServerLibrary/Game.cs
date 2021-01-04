using ServerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpServerLibrary;

namespace ServerLibrary
{
    public class Game
    {
        private int tmpValue = 0;
        public int numberValue;
        private int counter = 0;
        int score;

        public Game()
        {
            this.numberValue = randomInt();
            this.score = 100;
        }

        private int randomInt()
        {
            Random random = new Random();
            return random.Next(100);
        }

        public static void guessingGame(NetworkStream stream, MessageReader messageReader, ClientComunicator comunicator, User user)
        {
            int nextGame = 1;
            Game game = new Game();
            Console.WriteLine("Number to guess: " + game.numberValue);
            // comunicator.SendMessage(stream, messageReader.getMessage("guessMessage"));
            while (nextGame == 1)
            {

                var guessedVal = comunicator.ReadResponse(stream);

                String time = DateTime.Now.ToString("h:mm:ss");
                Console.WriteLine(time + " -> " + guessedVal);
                int guessedValInt;
                try
                {
                    guessedValInt = Int32.Parse(guessedVal);
                }
                catch (FormatException)
                {
                    guessedValInt = 102;
                }

                if ((guessedValInt > 100 || guessedValInt < 0) && guessedValInt != 10001)
                {
                    comunicator.SendMessage(stream, messageReader.getMessage("badValueMessage"));
                }
                else if (game.numberValue.Equals(guessedValInt))
                {
                    comunicator.SendMessage(stream, messageReader.getMessage("winningMessage"));
                    Console.WriteLine("Client guessed the number");
                    user.score = user.score + game.score;
                    game.score = 100;

                    //comunicator.SendMessage(stream, messageReader.getMessage("continueMessage"));
                    var continueGame = comunicator.ReadResponse(stream);

                    nextGame = Int32.Parse(continueGame);
                    if (nextGame == 0)
                    {
                        comunicator.SendMessage(stream, messageReader.getMessage("endMessage"));
                    }
                    else if (nextGame == 10001) {
                    }
                    else
                    {
                        game = new Game();
                        Console.WriteLine("Number to guess: " + game.numberValue);
                        comunicator.SendMessage(stream, messageReader.getMessage("guessMessage"));

                    }
                }
                else if (guessedValInt == 10001)
                {
                    nextGame = 0;
                }
                else
                {

                    string hotOrNotMessage = game.hotOrNot(guessedValInt);
                    comunicator.SendMessage(stream, hotOrNotMessage);

                }

                game.score = game.score - 3;

            }
        }

        public string hotOrNot(int guessedValue)
        {
            string hotOrNot = "";
            if (guessedValue < numberValue + 10 && guessedValue > numberValue - 10)
            {
                hotOrNot = " Goroco";
                counter = 0;
            }
            else if (guessedValue < numberValue + 25 && guessedValue > numberValue - 25)
            {
                hotOrNot = " Cieplo";
                if (guessedValue > numberValue && counter == 1)
                {
                    if (guessedValue - numberValue < tmpValue - numberValue)
                    {
                        hotOrNot = " Cieplej";
                    }
                }
                else if (guessedValue < numberValue && counter == 1)
                {
                    if (guessedValue - numberValue > tmpValue - numberValue)
                    {
                        hotOrNot = " Cieplej";
                    }
                }
                counter = 1;
            }

            else if (guessedValue < numberValue + 40 && guessedValue > numberValue - 40)
            {
                hotOrNot = " Zimno";
                counter = 0;
            }
            else
            {
                hotOrNot = " Mrozno";
                counter = 0;
            }
            tmpValue = guessedValue;
            return hotOrNot;
        }
    }
}
