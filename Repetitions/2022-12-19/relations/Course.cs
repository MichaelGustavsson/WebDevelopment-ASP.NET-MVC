namespace relations
{
    public class Course
    {
        public Guid CourseId { get; set; } = Guid.NewGuid();
        public string CourseNumber { get; set; } = "";
        public string CourseName { get; set; } = "";
        public List<Student> Students { get; set; } = new List<Student>();
    }
}