using System;
using System.Collections.Generic;
using System.Linq;
using BlaisePascal.LessonsExamples.Application.OrarioProfInfo;
using BlaisePascal.LessonsExamples.Application.OrarioProfInfo.Dto;
using BlaisePascal.LessonsExamples.Domain.OrarioProfInfo;
using BlaisePascal.LessonsExamples.Infrastracture.OrarioProfInfo;

string classesFilePath = Path.Combine("Data", "Classi.txt");
string teachersFilePath = Path.Combine("Data", "Docenti.txt");
string subjectsFilePath = Path.Combine("Data", "Discipline.txt");

List<string> classes = new ClassesTxtReader().Read(classesFilePath);
List<Prof> teachers = new TeacherTxtReader().Read(teachersFilePath);
List<Subject> subjects = new SubjectsTxtReader().Read(subjectsFilePath);

Console.WriteLine("=== Generazione orario in corso... ===\n");

GenerateUseCase useCase = new GenerateUseCase(teachers, subjects, classes);

int maxAttempts = 10000000;
List<CombinationDto>? combinations = useCase.Execute(maxAttempts);

if (combinations == null)
{
    Console.WriteLine($"Nessuna soluzione trovata entro {maxAttempts} tentativi.");
    return;
}

Console.WriteLine($"Soluzione trovata! ({combinations.Count} assegnazioni)\n");

Console.WriteLine("--- Orario per classe/materia ---");
foreach (CombinationDto combination in combinations)
{
    Console.WriteLine(combination);
}

List<ProfDto> profSummaries = teachers
    .Select(p => new ProfDto(p.Name, p.AssignedHours, p.TotalHours))
    .ToList();

Console.WriteLine("\n--- Riepilogo ore prof ---");
foreach (ProfDto teacher in profSummaries)
{
    Console.WriteLine(teacher);
}