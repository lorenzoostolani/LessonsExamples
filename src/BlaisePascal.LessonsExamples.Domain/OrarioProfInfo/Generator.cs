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

        //crea le varie combinazioni materia/anno
        private List<Combination> CreateCombination()
        {
            List<Combination> assignments = new List<Combination>();

            foreach (string className in classes)
            {
                int year = GetYear(className);

                foreach (Subject subject in subjects)
                {
                    if (subject.Year == year)
                    {
                        assignments.Add(
                            new Combination(className, subject)
                        );
                    }
                }
            }

            return assignments;
        }

        //prende l'anno dal nome della classe
        private int GetYear(string className)
        {
            return int.Parse(
                className.Substring(0, 1)
            );
        }

        //controlla che a un prof può essere assegnata una materia
        private bool CanAssign(Prof prof, Combination combination)
        {
            if (prof.RemainingHours() <
                combination.Subject.Hours)
            {
                return false;
            }

            return true;
        }


        public List<Combination>? Generate(int maxAttempts) 
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                // reset stato prof
                foreach (Prof prof in teachers)
                {
                    prof.AssignedHours = 0;
                }

                List<Combination> combinations = CreateCombination();

                bool success = true;

                foreach (Combination combination in combinations)
                {
                    // trova i prof candidati per questa combinazione
                    List<Prof> candidates = new List<Prof>();
                    foreach (Prof prof in teachers)
                    {
                        if (CanAssign(prof, combination))
                        {
                            candidates.Add(prof);
                        }
                    }

                    if (candidates.Count == 0)
                    {
                        success = false;
                        break;
                    }

                    Prof chosen = candidates[random.Next(candidates.Count)];

                    combination.Prof = chosen;
                    chosen.AssignedHours += combination.Subject.Hours;
                }

                if (success && AllHoursCompleted())
                {
                    Console.WriteLine($"Trovata al tentativo numero: {attempt + 1}"); //per debug
                    return combinations;
                }
            }

            return null;
        }

        private bool AllHoursCompleted()
        {
            foreach (Prof prof in teachers)
            {
                if (prof.AssignedHours != prof.TotalHours)
                {
                    return false;
                }
            }

            return true;
        }
    }





}

