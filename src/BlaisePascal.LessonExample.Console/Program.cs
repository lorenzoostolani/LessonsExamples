using System;
using System.Collections.Generic;
using BlaisePascal.LessonsExamples.Domain.OrarioProfInfo;

List<string> classes = new List<string>
{
    "1BIO",
    "1E",
    "1F",
    "1G",
    "1H",
    "1I",
    "1L",

    "2E",
    "2H",
    "2I",
    "2L",
    "2M",

    "3E",
    "3F",
    "3I",
    "3L",
    "3N",

    "4E",
    "4G",
    "4H",
    "4L",
    "4N",

    "5E",
    "5F",
    "5H",
    "5I"
};

List<Prof> teachers = new List<Prof>
{
    new Prof("Biondi", 18),
    new Prof("Fusaroli", 18),
    new Prof("Greco", 12),
    new Prof("Lucchi", 18),
    new Prof("Melagranati", 18),
    new Prof("Molara", 15),
    new Prof("Sintuzzi", 18),
    new Prof("Tappi", 18),
    new Prof("Vaccari", 18),
    new Prof("Veneti", 18),
    new Prof("Venturi", 18),
    new Prof("Facciponte", 18),
    new Prof("Supplente1", 18),
    new Prof("Supplente2", 9)
};

List<Subject> subjects = new List<Subject>
{
    new Subject("TI", 1, 3),

    new Subject("STA", 2, 3),

    new Subject("INF", 3, 6),
    new Subject("INF", 4, 6),
    new Subject("INF", 5, 6),

    new Subject("SR", 3, 4),
    new Subject("SR", 4, 4),
    new Subject("SR", 5, 4),

    new Subject("TPS", 3, 3),
    new Subject("TPS", 4, 3),
    new Subject("TPS", 5, 4),

    new Subject("GPOI", 5, 3)
};

Console.WriteLine("=== Generazione orario in corso... ===\n");

Generator generator = new Generator(teachers, subjects, classes);

int maxAttempts = 10000000;
List<Combination>? result = generator.Generate(maxAttempts);

if (result == null)
{
    Console.WriteLine($"Nessuna soluzione trovata entro {maxAttempts} tentativi.");
    return;
}

Console.WriteLine($"Soluzione trovata! ({result.Count} assegnazioni)\n");

Console.WriteLine("--- Orario per classe/materia ---");
foreach (Combination combination in result)
{
    Console.WriteLine(combination);
}

Console.WriteLine("\n--- Riepilogo ore prof ---");
foreach (Prof teacher in teachers)
{
    Console.WriteLine(teacher);
}