namespace Task_16_WebApi.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; } // "Active", "Inactive"

        public Course(int id, string name, int duration, string status)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Status = status;
        }
        public override string ToString()
        {
            return $"name: {Name}, id: {Id}, Duration: {Duration}, status: {Status}";
        }
    }
}
