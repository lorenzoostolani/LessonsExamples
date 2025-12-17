using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain
{
    public class ArrayTappiExsercise
    {
        public ArrayTappiExsercise() { }   
        public bool ContainsAllNumber(int[] array)
        {
            for (int i = 1; i < 10; i++)
            {
                if (!array.Contains(i)) 
                {
                    return false;
                }
            }
            return true;
        }

        public bool ContainsAllNumbersNoContains(int[] array)
        {
            for (int i = 1; i < 10; i++)
            {
                bool isContained = false;
                foreach (int n in array) 
                {
                    if (n == i)
                    {
                        isContained = true;
                        break;
                    }
                }
                if (!isContained)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
