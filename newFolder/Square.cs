
namespace battleship_warmup_csharp
{
    class Square
    {
        private bool isHit;
        private string symbol;

        public Square()
        {
            this.isHit = false;
            this.symbol = "*";
        }

        public void shoot()
        {
            this.isHit = true;
        }
        public bool IsHit() {
            return isHit;

        }
        public void SetSymbol (string symbol) {
            this.symbol = symbol;
        }
    
        public override string ToString() {
            return symbol;
        }
    }
}