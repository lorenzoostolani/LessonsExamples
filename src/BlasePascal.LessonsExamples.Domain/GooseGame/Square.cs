namespace BlasePascal.GooseGame.Domain
{
    public class Square
    {
        public int Num { get; private set; }
        public bool IsTrap {  get; private set; }
        public int Malus { get; private set; }
        public Square(int num) 
        {
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Num = num;
            IsTrap = false;

        }

        public void SetTrap(int malus) 
        {
            IsTrap = true;
            Malus = malus;
        }

    }
}
