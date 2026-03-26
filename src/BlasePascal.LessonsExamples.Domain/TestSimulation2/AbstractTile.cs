using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.TestSimulation2
{
    public abstract class AbstractTile: ISurface
    {
        public int UnitPrice { get; set; }

        public AbstractTile(int unitPrice)
        {
            UnitPrice = unitPrice;
        }

        public abstract int GetArea();
        public int GetCost() => UnitPrice;
    }
}
