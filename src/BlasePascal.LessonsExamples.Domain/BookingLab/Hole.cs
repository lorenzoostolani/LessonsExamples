using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Interview.Classroom.Domain.BookingLab
{
    public class Hole
    {
        public int Offset { get; private set; }
        public int Lenght { get; private set; }

        public Hole(int offset, int len) 
        {
            Offset = offset;
            Lenght = len;
        }
    }
}
