using System.Collections.Generic;
using System.Linq;
using BlaisePascal.LessonsExamples.Application.OrarioProfInfo.Dto;
using BlaisePascal.LessonsExamples.Domain.OrarioProfInfo;

namespace BlaisePascal.LessonsExamples.Application.OrarioProfInfo
{
    public class GenerateUseCase
    {
        private readonly List<Prof> teachers;
        private readonly List<Subject> subjects;
        private readonly List<string> classes;

        public GenerateUseCase(
            List<Prof> teachers,
            List<Subject> subjects,
            List<string> classes)
        {
            this.teachers = teachers;
            this.subjects = subjects;
            this.classes = classes;
        }

        public List<CombinationDto>? Execute(int maxAttempts)
        {
            Generator generator = new Generator(teachers, subjects, classes);

            List<Combination>? result = generator.Generate(maxAttempts);

            if (result == null)
            {
                return null;
            }

            return result.Select(c => new CombinationDto(
                    c.ClassName,
                    c.Subject.Name,
                    c.Subject.Hours,
                    c.Prof?.Name)).ToList();
        }
    }
}