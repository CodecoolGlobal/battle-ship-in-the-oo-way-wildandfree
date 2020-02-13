using System;

namespace battle_ship_in_the_oo_way_wildandfree
{
    class Cell
    {
        int PositionX, PositionY; // pobierane z Ocean.cs
        bool IsRestricted; // można postawić statek
        /* -- to do Ship.cs
        bool IsShoot; // statek trafiony 
        --- */
        string LetterToPrint; // znaki do ramki i opisu mapy
        public Cell(int positionX, int positionY, bool isRestricted) // Cell to draw elements of the map 
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.IsRestricted = isRestricted;
        }
        public Cell(int positionX, int positionY, string letterToPrint = "") // Cell to draw frame and 
        {                                                                       //letters
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.LetterToPrint = letterToPrint;
            this.IsRestricted = true;
        }
        // public Cell() { }
        public void setRestriction() // zmiana warunku postawienia znaku
        {
            IsRestricted = true;
        }
               public bool ifRestricted() // zwraca status pola - jeśli zajęte nie mozna postawić statku
        {
            return IsRestricted;
        }

        /* --- do Ship.cs
        public void setIsShoot() // zmiana kiedy trafiony
        {
            IsShoot = true;
        }
        -----*/

        public override string ToString()
        {
            /* --- to także do Ship.cs?
            if (IsShoot == true)
            {
                return String.Format("[X]");  // trafiony
            }
            else if (IsShoot == false)
            {
                return String.Format("[ ]"); // ustawiony
            }
            ---- */ 
            if (IsRestricted == true && LetterToPrint != "")
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