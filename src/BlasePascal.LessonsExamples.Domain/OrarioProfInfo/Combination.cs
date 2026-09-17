using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.OrarioProfInfo
{
    public class Combination
    {
        public string ClassName { get; set; }
        public Subject Subject { get; set; }
        public Prof? Prof { get; set; }

        public Combination(string className, Subject subject)
        {
            ClassName = className;
            Subject = subject;
            Prof = null;
        }

        public override string ToString()
        {
            if (Prof == null)
            {
                return $"{ClassName} - {Subject.Name} ({Subject.Hours} hours) - NON ASSEGNATO";
            }

            return $"{ClassName} - {Subject.Name} ({Subject.Hours} hours) - {Prof.Name}";
        }
    }
}
