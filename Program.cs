using System;
using System.Collections.Generic;
using System.Threading;

namespace battleship_warmup_csharp
{
    class Program
    {

        static void Main(string[] args)
        {
            // GamePlay.startGame("Battleships version 1.0 \n\nGame created by Andrzej && Mateusz","Let`s start");
            int playerOcean1 = 1;
            int playerOcean2 = 2;
            Ocean ocean1 = new Ocean(playerOcean1);
            Ocean ocean2 = new Ocean(playerOcean2);

            placeShipsOnBoard(ocean1);
            placeShipsOnBoard(ocean2);

            Ocean currentOcean = ocean2;
            string currentPlayer = "Player1";
            bool gameOver = false;
            while (!gameOver)
            {

                battle(currentOcean, currentPlayer);

                if (currentOcean.isGameOver())
                {
                    gameOver = true;
                    System.Console.WriteLine(GamePlay.howWin(currentOcean));
                    Thread.Sleep(500);
                }

                currentOcean = (currentOcean == ocean2) ? currentOcean = ocean1 : currentOcean = ocean2;
                currentPlayer = (currentPlayer == "Player1") ? currentPlayer = "Player2" : currentPlayer = "Player1";
            }
        }
        private static void battle(Ocean currentOcean, string currentPlayer)
        {
            string hiddenOcean = currentOcean.makeHiddenOcean(currentOcean.playerOcean);
            GamePlay.displayOcean(hiddenOcean);
            int x, y;
            x = ReadCoordinate("X", currentPlayer);
            y = ReadCoordinate("Y", currentPlayer);

            try
            {
                if (currentOcean.Shoot(x, y))
                {
                    System.Console.WriteLine("TRAFIONY!");
                    Thread.Sleep(1000);
                }
                else
                {
                    System.Console.WriteLine("PUDŁO!");
                    Thread.Sleep(1000);
                }
            }
            catch (ArgumentException e)
            {
                System.Console.WriteLine(e);
            }
            hiddenOcean = currentOcean.makeHiddenOcean(currentOcean.playerOcean);
            GamePlay.displayOcean(hiddenOcean.ToString());
            if (currentOcean.hasShipSunk())
            {
                GamePlay.DisplayMessage("hit and sunk");
            }
        }

        private static void placeShipsOnBoard(Ocean ocean)
        {

            int posX;
            int posY;
            int numberOfShipsBefore;

            foreach (KeyValuePair<string, int> ship in Ocean.shipsToLocate)
            {
                do
                {
                    System.Console.WriteLine(ocean);

                    numberOfShipsBefore = ocean.getNumberOfShips();

                    List<int> shipDetails = askPlayerForShipDetalis(new string[] { "Type X: ", "Type Y: " }, ship.Key);
                    string orientation = askForShipOrientation("vertical [type v] or horizontal [type h]");

                    posX = shipDetails[0];
                    posY = shipDetails[1];

                    ocean.AddShip(ship.Value, posX, posY, orientation);


                    // Thread.Sleep(1000);

                    // Console.Clear();
                } while (numberOfShipsBefore == ocean.getNumberOfShips());
            }
            GamePlay.displayOcean(ocean.ToString());
        }
        private static string getNameOfOcean(Ocean ocean)
        {
            return ocean.playerOcean == 1 ? "Player1 Ocean" : "Player 2 Ocean";
        }

        private static string askForShipOrientation(string orientation)
        {
            System.Console.WriteLine(orientation);
            string answer = System.Console.ReadLine();
            return answer;
        }

        private static List<int> askPlayerForShipDetalis(string[] questions, string shipName)
        {
            System.Console.WriteLine("Type cordinates for {0}", shipName);
            List<Int32> answers = new List<int>();
            foreach (var question in questions)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine();
                int cordidante;
                while (int.TryParse(answer, out cordidante) == false || int.Parse(answer) < 1 || int.Parse(answer) > 10)
                {
                    System.Console.WriteLine("Wrong. Please try again:\n{0}", question);
                    answer = System.Console.ReadLine();
                }
                answers.Add(cordidante);
            }
            return answers;
        }

        static int ReadCoordinate(string symbol, string currentPlayer)
        {
            int coor;

            Console.WriteLine(currentPlayer + " provide " + symbol);
            string input = Console.ReadLine();

            while (int.TryParse(input, out coor) == false | int.Parse(input) < 1 || int.Parse(input) > 10)
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Provide " + symbol);
                input = Console.ReadLine();
            }
            return coor;
        }
    }
}