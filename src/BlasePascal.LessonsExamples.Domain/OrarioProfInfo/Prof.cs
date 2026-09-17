using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.OrarioProfInfo
{
    public class Prof
    {
        public string Name { get; set; }
        public int TotalHours { get; set; }
        public int AssignedHours { get; set; }

        public Prof(string name, int totalHours)
        {
            Name = name;
            TotalHours = totalHours;
            AssignedHours = 0;
        }

        public int RemainingHours()
        {
            return TotalHours - AssignedHours;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
