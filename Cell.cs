using System;

namespace battle_ship_in_the_oo_way_wildandfree
{
    class Cell
    {
        int PositionX, PositionY; // pobierane z Ocean.cs
        bool IsRestricted; // można postawić statek
        bool isShoot; // statek trafiony 
        string LetterToPrint; // znaki do ramki i opisu mapy
        // bool isFrame;
        public Cell(int positionX, int positionY, bool isRestricted) // Cell to draw elements of the map 
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.IsRestricted = isRestricted;
        }
        public Cell(int positionX, int positionY, bool restriction, bool isshoot) // Cell to be ship
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.isShoot = isshoot;
        }
        public Cell(int positionX, int positionY, string letterToPrint = "") // Cell to draw frame and 
        {                                                                       //letters
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.LetterToPrint = letterToPrint;
            this.IsRestricted = true;
        }
        public Cell() { }
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
                return String.Format("[X]");  // trafiony
            }
            else if (isShoot == false)
            {
                return String.Format("[ ]"); // ustawiony
            }
            else if (IsRestricted == true && LetterToPrint != "")
            {
                return String.Format(LetterToPrint); // ramki i opisy
            }
            else
            {
                return String.Format("."); // puste pola
            }
        }

    }
}