namespace relations
{
    public class Student
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}