using System;
using System.Collections.Generic;
using System.IO;
using BlaisePascal.LessonsExamples.Domain.OrarioProfInfo;

namespace BlaisePascal.LessonsExamples.Infrastracture.OrarioProfInfo
{
    public class SubjectsTxtReader
    {
        public List<Subject> Read(string filePath)
        {
            List<Subject> subjects = new List<Subject>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');

                if (parts.Length != 3)
                {
                    throw new FormatException($"Riga discipline non valida: '{line}'");
                }

                string name = parts[0].Trim();
                int year = int.Parse(parts[1].Trim());
                int hours = int.Parse(parts[2].Trim());

                subjects.Add(new Subject(name, year, hours));
            }

            return subjects;
        }
    }
}