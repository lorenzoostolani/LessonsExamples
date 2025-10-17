using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain
{   
    public static class CharacterValidator
    {
        public const int MinHealth = 0;
        public const int MaxHealth = 100;

        public static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name.Trim()))
                throw new ArgumentException("Name cannot be null, empty, or whitespace.");
            
            return name;
        }

        public static int ValidateHealth(int health)
        {
            if (health < MinHealth || health > MaxHealth)
                throw new ArgumentOutOfRangeException($"Health must be between {MinHealth} and {MaxHealth}.");
            return health;
        }

    }
}
