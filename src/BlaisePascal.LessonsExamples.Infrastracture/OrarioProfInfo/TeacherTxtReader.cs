using System;
using System.Collections.Generic;
using System.IO;
using BlaisePascal.LessonsExamples.Domain.OrarioProfInfo;

namespace BlaisePascal.LessonsExamples.Infrastracture.OrarioProfInfo
{
    public class TeacherTxtReader
    {
        public List<Prof> Read(string filePath)
        {
            List<Prof> teachers = new List<Prof>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');

                if (parts.Length != 2)
                {
                    throw new FormatException($"Riga docenti non valida: '{line}'");
                }

                string name = parts[0].Trim();
                int totalHours = int.Parse(parts[1].Trim());

                teachers.Add(new Prof(name, totalHours));
            }

            return teachers;
        }
    }
}
