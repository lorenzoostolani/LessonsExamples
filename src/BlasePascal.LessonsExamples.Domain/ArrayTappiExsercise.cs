using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain
{
    public class ArrayTappiExsercise
    {
        public int[] Array { get; private set; }

        public ArrayTappiExsercise(int[] array)
        {
            Array = array;
        }

        public bool ContainsAllNumber()
        {
            for (int i = 1; i < 10; i++)
            {
                if (!Array.Contains(i)) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
