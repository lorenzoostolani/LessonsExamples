using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Student.Domain
{
    public class Grades
    {
        public string Subject { get; private set; }
        public double Value { get; private set; } 
        public DateTime Date { get; private set; }

        public Grades(string subject, double value)
        {
            Subject = subject;
            Value = value;
            Date = DateTime.Now;
        }
    }
}
