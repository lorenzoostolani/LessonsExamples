using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain
{
    public class Lamp
    {
        public Guid Id { get; init; }
        public int Intensity { get; private set; }
        public Color Color { get; private set; }

        public Lamp()
        {
            Id = Guid.NewGuid();
            Color = new Color(255, 255, 255);
        }

        public void ChangeColorTo(Color newColor)
        {
            Color = newColor;
            Color.red = 0;
            Color = new Color(0, 0, 0);
        }


    }

    public sealed record Color(int red, int green, int blue);
}
