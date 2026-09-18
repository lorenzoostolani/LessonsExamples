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

        public int FindMostFrequentNumber(int[] array) 
        {
            int[] count = new int[10];
            for (int i = 1; i < 10; i++)
            {
                foreach(int num in array)
                {
                    if (num == i)
                        count[i]++;
                }
            }

            int mostFrequentnNum = 0;
            int highestFrequence = 0;
            for (int i = 1; i < count.Length; i++)
            {
                if (count[i] > highestFrequence)
                {
                    mostFrequentnNum = i;
                    highestFrequence = count[i];
                }
            }
            return mostFrequentnNum;
        }
    }
}
