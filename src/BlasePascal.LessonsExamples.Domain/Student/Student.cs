using System.Runtime.CompilerServices;

namespace BlaisePascal.Student.Domain
{
    public class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Id { get; private set; }

        public List<Grades> Grades { get; private set; }
        public HashSet<string> Subjects { get; private set; }

        public Student(string name, string surname, string id)
        {
            Name = name;
            Surname = surname;
            Id = id;
            Grades = new List<Grades>();
            Subjects = new HashSet<string>();
        }

        public void AddGrade(Grades grade)
        {
            Grades.Add(grade);
            Subjects.Add(grade.Subject);
        }

        public double GetAverage(string subject)
        {
            double sum = 0;
            int count = 0;

            for (int i = 0; i < Grades.Count; i++)
            {
                if (Grades[i].Subject == subject)
                {
                    sum += Grades[i].Value;
                    count++;
                }
            }

            return sum / count;
        }

        public string GetBestSubject()
        {
            double bestAverage = double.MinValue;
            string bestSubject = string.Empty;

            for (int i = 0; i < Grades.Count; i++)
            {
                Subjects.Add(Grades[i].Subject);
            }
            for (int i = 0; i < Subjects.Count; i++)
            {
                double average = GetAverage(Subjects.ElementAt(i));
                if (average > bestAverage)
                {
                    bestAverage = average;
                    bestSubject = Subjects.ElementAt(i);
                }
            }
            return bestSubject;
        }
    }
}


