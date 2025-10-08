namespace BlaisePascal.LessonsExamples.Domain
{
    public class Enemy
    {
        //TODO: Attributes decomposition
        // Attributes
        private string _name;
        private string _description;
        private int _health;
        private bool _isAlive;
        private int _attackDamage;
        private int _attackSpeed;
        private int _damageReduction;
        private int _positionX;
        private int _positionY;
        private int _movementSpeed;

        // Constructor
        public Enemy() { }
        public Enemy(string name)
        {
            SetName(name);
        }
        public Enemy(string name, int health)
        {
            SetName(name);
            SetHealth(health);

        }

        // Function
        public void SetName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
                _name = newName;
        }

        public void SetHealth(int newHealth)
        {
            if (int.IsPositive(newHealth) && newHealth <= 100)
                _health = newHealth;
        }

        public string GetName()
        { 
            return _name; 
        }
        public int GetHealth()
        {
            return _health;
        }

    }


}
