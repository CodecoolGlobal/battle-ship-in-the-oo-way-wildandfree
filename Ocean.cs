using System;
using System.Collections.Generic;
using System.Threading;

namespace battleship_warmup_csharp
{
    public class Ocean
    {
        public static readonly int WIDTH = 12;
        public static readonly int HEIGHT = 12;
        private List<List<Square>> board;
        private List<Ship> ships = new List<Ship>();

        public int playerOcean { get; set; }

        public static readonly Dictionary<string, int> shipsToLocate = new Dictionary<string, int> {
            // { "Carrier", 5},
            // { "Battleship", 4},
            // { "Crusier", 3}, 
            // { "Submarine", 3},
            { "Destroyer", 2 }
        };

        public bool isGameOver()
        {
            foreach (var line in board)
            {
                foreach (var square in line)
                {
                    if (square.GetSymbol() == "S")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // ("Carrier":5, "Battleship":4, "Crusier":3, "Sumbarine":3, "Destroyer":2 };

        public Ocean(int playerOcean)
        {
            this.playerOcean = playerOcean;
            board = new List<List<Square>>();
            ships = new List<Ship>();

            List<Square> row;
            for (int i = 0; i < HEIGHT; i++)
            {
                row = new List<Square>();
                for (int j = 0; j < WIDTH; j++)
                {
                    if (i == 0)
                    {
                        row.Add(new Square("-"));
                    }
                    else if (j == 0)
                    {
                        row.Add(new Square("|"));
                    }
                    else if (j == WIDTH - 1)
                    {
                        row.Add(new Square("|"));
                    }
                    else if (i == HEIGHT - 1)
                    {
                        row.Add(new Square("-"));
                    }
                    else
                    {
                        row.Add(new Square());
                    }

                }
                board.Add(row);
            }
        }

        public bool AddShip(int shipLength, int x, int y, string orientation)
        {
            List<Square> squares = new List<Square>();

            bool makeAShip = true;
            if (makeAShip == true)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    makeAShip = canWeMakeAShipHere(x, y, shipLength, orientation);
                    if (makeAShip && orientation == "v")
                    {
                        squares.Add(board[y + i][x]);
                    }
                    else if (makeAShip)
                    {
                        squares.Add(board[y][x + i]);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            ships.Add(new Ship(squares, "S"));
            System.Console.WriteLine(ships);
            return true;
        }

        public bool hasShipSunk()
        {
            foreach (Ship ship in ships)
            {
                foreach (Square square in ship)
                {
                    if (square.GetSymbol() == "S")
                    {
                        return false;
                    }
                }

            }
            return true;
        }


        private bool canWeMakeAShipHere(int x, int y, int shipLength, string orientation)
        {
            if ((y + shipLength > board.Count - 1 && orientation == "v") ||
                  (x + shipLength > board[0].Count - 1 && orientation == "h"))
            {
                System.Console.WriteLine("Ship is to long to place it here");
                return false;
            }

            

            for (int i = 0; i < shipLength; i++)
            {
                if (orientation == "v")
                {
                    if ((board[y + i][x - 1].GetSymbol() == "S" || board[y + i][x + 1].GetSymbol() == "S") || board[y + i][x].GetSymbol() == "S")
                    {
                        System.Console.WriteLine("occupeided");
                        return false;
                    }
                }

                else if (orientation == "h")
                {
                    if ((board[y + 1][x + i].GetSymbol() == "S") || //S
                    (board[y - 1][x + i].GetSymbol() == "S") || // N
                    (board[y][x + i].GetSymbol() == "S") || //the same field
                    (board[y][x - 1].GetSymbol() == "S") || //W
                    (board[y][x + 1].GetSymbol() == "S") || //E
                    (board[y - 1][x + i - 1].GetSymbol() == "S")) //WN

                    {
                        System.Console.WriteLine("occupied");
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Shoot(int x, int y)
        {

            Square square = board[y][x];

            square.shoot();

            foreach (Ship ship in ships)
            {
                if (ship.Contains(square))
                {
                    square.SetSymbol("X");
                    return true;
                }
            }
            square.SetSymbol("O");
            return false;
        }
        public int getNumberOfShips()
        {
            return ships.Count;
        }

        public override string ToString()
        {

            string str = string.Format("Player {0} Ocean\n  12345678910\n", playerOcean);
            int ascii = 96;
            for (int i = 0; i < board.Count; i++)
            {
                if (i == 0)
                {
                    str += " ";
                }
                else if (i == board.Count - 1)
                {
                    str += " ";
                }
                else
                {
                    str = str + (char)ascii;
                }

                foreach (Square square in board[i])
                {
                    str = str + square.ToString();
                }
                str = str + "\n";
                ascii++;
            }
            return str;
        }
        public string makeHiddenOcean(int boardNumber)
        {

            string str = string.Format("Player {0} Ocean\n  12345678910\n", playerOcean);
            int ascii = 96;
            for (int i = 0; i < board.Count; i++)
            {
                if (i == 0)
                {
                    str += " ";
                }
                else if (i == board.Count - 1)
                {
                    str += " ";
                }
                else
                {
                    str = str + (char)ascii;
                }

                foreach (Square square in board[i])
                {
                    if(square.GetSymbol()=="S"){
                        str += "*";
                    }
                    else
                    {
                        str = str + square.ToString();
                    }
                }
                str = str + "\n";
                ascii++;
            }
            return str;
        }
    }
}