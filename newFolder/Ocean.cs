using System;
using System.Collections.Generic;
namespace battleship_warmup_csharp
{
    public class Ocean{

        public static readonly int WIDTH = 10;
        public static readonly int HEIGHT = 10;
        private List<List<Square>> board;
        private List<Ship> ships;

        public Ocean(){
            board = new List<List<Square>>();
            ships = new List<Ship>();

            List<Square> row;
            for (int i = 0; i < HEIGHT; i++){
                row = new List<Square>();
                for (int j = 0; j < WIDTH; j++){
                    row.Add(new Square());
                }
                board.Add(row);
            }
        }

        public bool AddShip(int shipLength, int x, int y) { 
            if (x < 0 || x >= WIDTH)
                throw new ArgumentException("x coordinate should be in range 0..9");
            if (y < 0 || y >= HEIGHT)
                throw new ArgumentException("y coordinate should be in range 0..9");
            if (shipLength < 1 || shipLength > 4)
                throw new ArgumentException();
            
            List<Square> squares = new List<Square>();
            for (int i = 0 ; i < shipLength ; i++)
                squares.Add(board[y][x + i]);
            
            ships.Add(new Ship(squares));
            System.Console.WriteLine(ships);
            return true;
        }

        public bool Shoot(int x, int y) {
            if (x < 0 || x >= WIDTH)
                throw new ArgumentException("x coordinate should be in range 0..9");
            if (y < 0 || y >= HEIGHT)
                throw new ArgumentException("y coordinate should be in range 0..9");

            Square square = board[x][y];
            
            square.shoot();

            foreach (Ship ship in ships) {

                if (ship.Contains(square)) {
                    square.SetSymbol("X");
                    return true;
                }
            }
            square.SetSymbol("O");
            return false;

        }
        
        public override string ToString(){

            string str = " 12345678910\n";
            int ascii = 97;
            foreach (List<Square> row in board) {
                str = str + (char)ascii;
                foreach (Square square in row) {
                    str = str + square.ToString();
                }
                str  = str + "\n";
                ascii++;
            }
            return str;
        }
    }
}