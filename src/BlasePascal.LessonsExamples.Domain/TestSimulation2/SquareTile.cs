using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.TestSimulation2
{

    public class SquareTile : AbstractTile
    {
        public int Side { get; set; }

        public SquareTile(int side, int unitPrice) : base(unitPrice) { Side=side; }

        public override int GetArea()
        {
            return Side*Side;
        }
    }
}
