using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.OrarioProfInfo
{
    public class Subject
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Hours { get; set; }

        public Subject(string name, int year, int hours)
        {
            Name = name;
            Year = year;
            Hours = hours;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
