using System;
using System.Collections.Generic;
using System.IO;

namespace BlaisePascal.LessonsExamples.Infrastracture.OrarioProfInfo
{
    public class ClassesTxtReader
    {
        public List<string> Read(string filePath)
        {
            List<string> classes = new List<string>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] values = line.Split(';');

                foreach (string value in values)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        classes.Add(value.Trim());
                    }
                }
            }

            return classes;
        }
    }
}