namespace relations;
class Program
{
    static void Main(string[] args)
    {
        var courseJs = new Course
        {
            CourseName = "Intro till JavaScript",
            CourseNumber = "2319"
        };
        var courseSql = new Course
        {
            CourseName = "Administration av SQL Server",
            CourseNumber = "2108"
        };

        var studentMichael = new Student
        {
            FirstName = "Michael",
            LastName = "Gustavsson"
        };
        var studentAnnika = new Student
        {
            FirstName = "Annika",
            LastName = "Gustavsson"
        };

        studentMichael.Courses.Add(courseJs);
        studentMichael.Courses.Add(courseSql);

        studentAnnika.Courses.Add(courseJs);

        // Kontrollera vilka kurser som Michael är anmäld på...
        Console.WriteLine("");
        Console.WriteLine("---------Michael-----------");
        foreach (var course in studentMichael.Courses)
        {
            Console.WriteLine("{0}, {1}", course.CourseNumber, course.CourseName);
        }
        // Kontrollera vilka kurser som Michael är anmäld på...
        Console.WriteLine("");
        Console.WriteLine("---------Annika-----------");
        foreach (var course in studentAnnika.Courses)
        {
            Console.WriteLine("{0}, {1}", course.CourseNumber, course.CourseName);
        }

        // Hantera kurser och studenter...
        courseJs.Students.Add(studentAnnika);
        courseJs.Students.Add(studentMichael);
        courseSql.Students.Add(studentMichael);

        Console.WriteLine("");
        Console.WriteLine("---------JavaScript-----------");
        foreach (var student in courseJs.Students)
        {
            Console.WriteLine("{0}, {1}", student.FirstName, student.LastName);
        }

        Console.WriteLine("");
        Console.WriteLine("---------SQL Server-----------");
        foreach (var student in courseSql.Students)
        {
            Console.WriteLine("{0}, {1}", student.FirstName, student.LastName);
        }

    }
}
