using System;


namespace battle_ship_in_the_oo_way_wildandfree
{
    public class Board
    {
        object[,] grid = new object[14, 14];
        string[] horizontal_strings = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        string[] vertical_strings = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public string getStrings(string[] arr, int param) // zwraca string drukowany na mapie
        {                                                  // jako frame lub opis 
            return arr[param];
        }
        public object[,] CreateOcean()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == 0 || i == grid.GetLength(0))
                    {
                        var letter = getStrings(horizontal_strings, i);
                        grid[i, j] = (new Square(i, j, letter)); // to jest frame - litery!
                    }
                    else if (j == 0 || j == grid.GetLength(1))
                    {
                        var letter = getStrings(vertical_strings, j);
                        grid[i, j] = (new Square(i, j, letter)); // to jest frame - cyfry!
                    }
                    else if (i == 1 || i == grid.GetLength(0) - 1)
                    {
                        string horizontal = "|";
                        grid[i, j] = (new Square(i, j, horizontal)); // to jest frame kreski pionowe!
                    }
                    else if (j == 1 || j == grid.GetLength(1) - 1)
                    {
                        string vertical = "–";
                        grid[i, j] = (new Square(i, j, vertical)); // to jest frame kreski poziome!
                    }
                    else if (i == 2 || i == grid.GetLength(0) - 2 || j == 2 || j == grid.GetLength(1) - 2)
                    {
                        grid[i, j] = (new Square(i, j, true)); // nie można postawić statku
                    }
                    else
                    {
                        grid[i, j] = (new Square(i, j, false)); // można postawić statek 
                    }
                }

            }
            return grid;
        }
        public void updateOcean()
        {
        }
        public void checkIfFree()
        {

        }
    }
}