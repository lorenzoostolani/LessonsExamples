namespace BlaisePascal.LessonsExamples.Domain
{
    public class Enemy
    {

        // Attributes
        /*
        private string _name;
        private string _description;
        private int _health;
        private bool _isAlive;
        */


        // Properties

        public int Health { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsAlive { get; private set; }

        // Constructor
        public Enemy() { }
        public Enemy(string name)
        {
            Name = name;
            IsAlive = true;
        }
        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
            IsAlive = true;

        }

        // Function
        public void SetName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
                Name = newName;
                
        }

        public void SetHealth(int newHealth)
        {
            if (int.IsPositive(newHealth) && newHealth <= 100)
                Health = newHealth;

        }


        public void TakeDamage(int damage)
        {
            if (int.IsNegative(damage))
                throw new ArgumentOutOfRangeException("Damage cannot be negative");
            if (damage < Health && IsAlive == true)
            {
                // Health Math.Min(0, Health damage);
                Health -= damage;
            }
            else
            {
                Health = 0;
                IsAlive = false;
            }



        }


}
