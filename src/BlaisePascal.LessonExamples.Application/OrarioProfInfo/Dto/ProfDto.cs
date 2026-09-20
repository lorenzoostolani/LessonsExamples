namespace BlaisePascal.LessonsExamples.Application.OrarioProfInfo.Dto
{
    public class ProfDto
    {
        public string Name { get; set; }
        public int AssignedHours { get; set; }
        public int TotalHours { get; set; }

        public ProfDto(string name, int assignedHours, int totalHours)
        {
            Name = name;
            AssignedHours = assignedHours;
            TotalHours = totalHours;
        }

        public override string ToString()
        {
            return $"{Name} ({AssignedHours}/{TotalHours} ore)";
        }
    }
}