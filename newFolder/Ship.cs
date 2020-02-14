using System.Collections.Generic;

namespace battleship_warmup_csharp
{    
    class Ship {
        private List<Square> squares;

        public Ship(List<Square> squares)
        {
            this.squares = squares;
        }

        public bool Contains(Square square) 
        {
            return squares.Contains(square);
        }
    }
}