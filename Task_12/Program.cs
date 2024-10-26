using System.Linq;

namespace Task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ Expressions

            #region Display numbers without any repeated Data and sorted && using Query1 result and show each number and it’s multiplication
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var list = numbers.Select(x => x).OrderBy(x => x).Distinct().ToList();
            foreach ( var item in list )
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------------------------------------");
            var listmult = list.Select(x => x * x).ToList();
            for( int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{{ Number = {list[i]}, Multibly = {listmult[i]} }}");
            }
            #endregion
            Console.WriteLine("---------------------------------------------------------------------");

            #region Select names with length equal 3 && Select names that contains “a” letter (Capital or Small)then sort them by lengtt && Display the first 2 names 
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            var names_req = names.Where(x => x.Length == 3).ToList();
            foreach( string name in names_req)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("---------------------------------------------------------------------");
            var names_req2 = names.Where(x => x.Contains('a') || x.Contains('A')).OrderBy(x => x.Length).ToList();
            foreach( string name in names_req2)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("---------------------------------------------------------------------");
            var names_req3 = names.Take(2).ToList();
            foreach(string name in names_req3)
                Console.WriteLine(name);
            #endregion
            Console.WriteLine("---------------------------------------------------------------------");
            #region Display Full name and number of subjects for each student as follow
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    ID = 1,
                    FirstName = "Ali",
                    LastName = "Mohammed",
                    Subjects = new Subject[]
                    {
                        new Subject { Code = 22, Name = "EF" },
                        new Subject { Code = 33, Name = "UML" }
                    }
                },
                new Student
                {
                    ID = 2,
                    FirstName = "Mona",
                    LastName = "Gala",
                    Subjects = new Subject[]
                    {
                        new Subject { Code = 22, Name = "EF" },
                        new Subject { Code = 34, Name = "XML" },
                        new Subject { Code = 25, Name = "JS" }
                    }
                },
                new Student
                {
                    ID = 3,
                    FirstName = "Yara",
                    LastName = "Yousf",
                    Subjects = new Subject[]
                    {
                        new Subject { Code = 22, Name = "EF" },
                        new Subject { Code = 25, Name = "JS" }
                    }
                },
                new Student
                {
                    ID = 1,
                    FirstName = "Ali",
                    LastName = "Ali",
                    Subjects = new Subject[]
                    {
                        new Subject { Code = 33, Name = "UML" }
                    }
                }
            };

            var std = students.Select(s => new {Fullname = s.FirstName + " " + s.LastName, NoOfSubjects = s.Subjects.Length}).ToList();
            foreach(var student in std)
                Console.WriteLine(student);
            Console.WriteLine("---------------------------------------------------------------------");
            var std2 = students.Select(s => new { Fullname = s.FirstName + " " + s.LastName }).OrderByDescending(x => x.Fullname).ToList();
            foreach (var student in std2)
                Console.WriteLine(student);
            #endregion

            #endregion
        }

    }

    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] Subjects { get; set; }
    }
}
