using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.TestSimulation2
{
    public class TriangularTile: AbstractTile
    {
        public int Height { get; set; }
        public int Base { get; set; }

        public TriangularTile(int _height, int _base, int unitPrice): base(unitPrice) { Height = _height; Base = _base; }

        public override int GetArea()
        {
            return Base*Height;
        }
    }
}
