using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.TestSimulation2
{
    public class RhombusTile : AbstractTile
    {
        public int Diagonal1 { get; set; }
        public int Diagonal2 { get; set; }

        public RhombusTile(int diagonal1, int diagonal2, int unitPrice) : base(unitPrice) { Diagonal1 = diagonal1; Diagonal2 = diagonal2; }

        public override int GetArea()
        {
            return Diagonal1*Diagonal2/2;
        }
    }
}
