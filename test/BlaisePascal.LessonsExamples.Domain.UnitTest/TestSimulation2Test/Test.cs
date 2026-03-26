using BlaisePascal.LessonsExamples.Domain.TestSimulation2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.UnitTest.TestSimulation2Test
{
    public class TestClass
    {
        public static void Run()
        {
            var objects = new Dictionary<int, ISurface>();
            var floorings = new List<Flooring>();
            string line;
            int row = 0;

            while ((line = Console.ReadLine()) != null && line != "")
            {
                var parts = line.Split(' ');
                char action = parts[0][0];

                if (action == 'Q')
                    objects[row] = new SquareTile(int.Parse(parts[1]), int.Parse(parts[2]));
                else if (action == 'R')
                    objects[row] = new RhombusTile(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                else if (action == 'T')
                    objects[row] = new TriangularTile(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                else if (action == 'P')
                {
                    var f = new Flooring();
                    for (int i = 1; i < parts.Length; i += 2)
                        f.AddSurface(int.Parse(parts[i]), objects[int.Parse(parts[i + 1])]);
                    objects[row] = f;
                    floorings.Add(f);
                }

                row++;
            }

            foreach (var f in floorings)
                Console.WriteLine($"{f.GetArea()}\t{f.GetCost()}");
        }
    }
/*

** Output atteso con l'input d'esempio:**
```
168    126
260    325
688    776*/
}
