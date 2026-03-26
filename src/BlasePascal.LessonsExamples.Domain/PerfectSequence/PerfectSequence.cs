using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlaisePascal.LessonsExamples.Domain.PerfectSequence
{
    public class PerfectSequence
    {
        public int[] Sequence {  get; set; }

        public PerfectSequence(int[] sequence) {  Sequence = sequence; }

        
        public bool isPerfect()
        {
            //Controllo lunghezza
            if (Sequence.Length != 27)
                return false;


            //Controllo che i numeri siano giusti

            int[] count = new int[10];
            foreach (int num in Sequence)
            {
                if (num > 9 || num < 1) { return false; }

                count[num]++;
            }
            for (int i = 1; i <= 9; i++) 
            {
                if (count[i] != 3)
                    return false;
            }

            //Controllo che la sequenza sia corretta
            for (int i=1; i<=9; i++)
            {
                int pos = Array.IndexOf(Sequence, i);
                if (pos + i + 1> 26) {  return false; }
                if(Sequence[pos + i +1] != i) {  return false; }
                pos += i+1;
                if (pos + i +1 > 26) { return false; }
                if (Sequence[pos + i+1] != i) { return false; }
            }

            return true;
        }
    }
}
