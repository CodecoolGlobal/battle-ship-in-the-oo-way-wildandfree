using System;

namespace battleship_warmup_csharp
{
    class Program
    {
        static void Main(string[] args)
        {   
            Ocean ocean = new Ocean();
            ocean.AddShip(3, 0, 2);
            ocean.AddShip(4, 5, 8);
            int x, y;

            while (true) {
                System.Console.WriteLine(ocean);
    
                x = ReadCoordinate("X");
                y = ReadCoordinate("Y");

                try {
                    if (ocean.Shoot(x, y))
                        System.Console.WriteLine("TRAFIONY!");
                    else
                        System.Console.WriteLine("PUDŁO!");
                } catch (ArgumentException e) {
                    System.Console.WriteLine(e);
                }
                    
                }
        }

        static int ReadCoordinate(string symbol) {

        int coor;

        Console.WriteLine("Provide " + symbol);
        string input = Console.ReadLine();

        while (Int32.TryParse(input, out coor) == false)
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Provide " + symbol);
            input = Console.ReadLine();
        }
        return coor;
            
        }

        
    }   
}
