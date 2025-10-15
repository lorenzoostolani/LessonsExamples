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
        public bool IsAlive => Health > 0;



        // Constructor
        public Enemy() { }
        public Enemy(string name)
        {
            Name = name;

        }
        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;

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
            {
                Health = newHealth;
            }
            else
            {
                throw new ArgumentException("Healt is out of range");
            }
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative");

            Health = Math.Max(CharacterValidator.MinHealth, Health -= damage);

        }
        public void Heal(int healAmount)
        {
            if (healAmount < 0)
                throw new ArgumentException("Heal amount cannot be negative");

    
            Health = Math.Min(CharacterValidator.MaxHealth, Health += healAmount);

        }
    }
}
