using System;

namespace BlaisePascal.LessonsExamples.Application.OrarioProfInfo.Dto
{
    public class CombinationDto
    {
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public int Hours { get; set; }
        public string? ProfName { get; set; }

        public CombinationDto(string className, string subjectName, int hours, string? profName)
        {
            ClassName = className;
            SubjectName = subjectName;
            Hours = hours;
            ProfName = profName;
        }

        public override string ToString()
        {
            string assegnazione = ProfName ?? "NON ASSEGNATO";
            return $"{ClassName} - {SubjectName} ({Hours} hours) - {assegnazione}";
        }
    }
}