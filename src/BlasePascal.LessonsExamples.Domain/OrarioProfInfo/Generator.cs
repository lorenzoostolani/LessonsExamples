using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.OrarioProfInfo
{
    public class Generator
    {
        private Random random = new Random();

        private readonly List<Prof> teachers;
        private readonly List<Subject> subjects;
        private readonly List<string> classes;

        public Generator( List<Prof > teachers, List<Subject> subjects, List<string> classes)
        {
            this.teachers = teachers;
            this.subjects = subjects;
            this.classes = classes;
        }

        public List<Combination>? Generate(int maxAttempts) { }


    }
}
