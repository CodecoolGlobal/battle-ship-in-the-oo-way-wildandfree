using System.Collections.Generic;

namespace battleship_warmup_csharp {
    class Ship {
        public List<Square> squares { get; set; }

        public IEnumerator<Square> GetEnumerator () // żeby iterować po statkach w funkcji isShipSinking();
        {
            return squares.GetEnumerator ();
        }

        public Ship (List<Square> squares, string symbol) { // do rozmieszania statkow
            this.squares = squares;
            for (int i = 0; i < squares.Count; i++) {
                squares[i].SetSymbol (symbol);
            }
        }

        public bool Contains (Square square) {
            return squares.Contains (square);
        }
    }
}