using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.TestSimulation2
{
    public class Flooring: ISurface
    {

        public Flooring() { Surfaces = new List<ISurface>(); }
        public List<ISurface> Surfaces { get; set; }

        public void AddSurface(int quantity, ISurface surface)
        {
            for (int i = 0; i < quantity; i++)
                Surfaces.Add(surface);

        }

        public int GetCost()
        {
            int total = 0;
            foreach (var s in Surfaces)
            {
                total += s.GetCost();
            }
            return total;

        }
        public int GetArea()
        {
            int total = 0;
            foreach (var s in Surfaces)
            {
                total += s.GetArea();
            }
            return total;
        }
    }
}
