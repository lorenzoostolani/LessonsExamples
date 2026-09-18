using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain
{
    public class Hero
    {
        //Attributes

        private string _name;
        private int _health;
        private string _description;
        private bool _isAlive;

        //Contructor
        public Hero()
        {
        }
        public Hero(string name)
        {
            _name = name;
        }

        public Hero(string name, int health)
        {
            _name = name;
            _health = health;
        }

        //Functions

        public string GetName()
        {
            return _name;
        }

        public int GetHealth()
        {
            return _health;
        }


        public void SetName(string newName)
        {
            _name = CharacterValidator.ValidateName(newName);
        }

        public void SetHealth(int newHealth)
        {
            _health = CharacterValidator.ValidateHealth(newHealth);
        }

        public void isAlive()
        {
            _isAlive = _health > 0;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative");

            _health = Math.Max(CharacterValidator.MinHealth, _health -= damage);

        }
        public void Heal(int healAmount)
        {
            if (healAmount < 0)
                throw new ArgumentException("Heal amount cannot be negative");


            _health = Math.Min(CharacterValidator.MaxHealth, _health += healAmount);

        }

    }
}
