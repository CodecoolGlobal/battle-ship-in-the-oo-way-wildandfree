using System;

namespace battle_ship_in_the_oo_way_wildandfree
{
    class Square
    {
        int PositionX, PositionY; // pobierane z Ocean.cs
        bool IsRestricted; // można postawić statek
        bool isShoot; // statek trafiony 
        string LetterToPrint; // znaki do ramki i opisu mapy
        // bool isFrame;
        public Square(int positionX, int positionY, bool isRestricted) // square to draw elements of the map 
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.IsRestricted = isRestricted;
        }
        public Square(int positionX, int positionY, bool restriction, bool isshoot) // square to be ship
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.isShoot = isshoot;
        }
        public Square(int positionX, int positionY, string letterToPrint = "") // square to draw frame and 
        {                                                                       //letters
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.LetterToPrint = letterToPrint;
            this.IsRestricted = true;
        }
        public Square() { }
        public void setRestriction() // zmiana warunku postawienia znaku
        {
            IsRestricted = true;
        }
        public string drawFrame() // rozbudować w zależności co się będzie działo
        {
            return LetterToPrint;
        }

        public override string ToString()
        {
            if (isShoot == true)
            {
                return String.Format("[X]");
            }
            else if (isShoot == false)
            {
                return String.Format("[ ]");
            }
            else if (IsRestricted == true && LetterToPrint != "")
            {
                return String.Format(LetterToPrint);
            }
            else
            {
                return String.Format(".");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}