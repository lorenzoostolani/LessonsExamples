namespace BlaisePascal.Coin.Domain
{
    public class Coin
    {
        public string Value { get; private set; }
        private Random _random;

        public Coin(): this(new Random()) { }
        public Coin(Random random)
        {
            _random = random;
        }

        public void Throw()
        {
            
            if (_random.Next(0, 2) == 0)
            {
                Value = "Heads";
            }
            else
            {
                Value = "Tails";
            }
            
        }

    }
}
