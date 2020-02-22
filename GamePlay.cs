using System;
using System.Collections.Generic;
using System.Threading;

namespace battleship_warmup_csharp
{
    public class GamePlay
    {
        public static void displayOcean(string ocean){
            // Console.Clear();
            System.Console.WriteLine(ocean);
            Thread.Sleep(500);
            
        }

        internal static void startGame(string message1, string message2)
        {
            // Console.Clear();
            for (int i = 0; i < message1.Length; i++)
            {
                Console.Write(message1[i]);
                Thread.Sleep(60);
            }
            Thread.Sleep(1500);
            // Console.Clear();
            for (int i = 0; i < message2.Length; i++)
            {
                Console.Write(message2[i]);
                Thread.Sleep(100);
            }
            Thread.Sleep(1500);
            // Console.Clear();
        }

        internal static string howWin(Ocean currentOcean)
        {
            return currentOcean.playerOcean== 1 ? "Player 2 wins" : "Player 1 wins";
        }

        internal static void DisplayMessage(string message)
        {
            System.Console.WriteLine(message);
            Thread.Sleep(1500);
        }
    }
}