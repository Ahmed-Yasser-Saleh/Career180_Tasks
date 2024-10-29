using System.Linq;
using Task_13.Models;

namespace Task_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItiProjectContext db = new ItiProjectContext();
            var tr = db.Trainees.Where(T => T.Id > 2).ToList();
            foreach(var item in tr)
            {
                Console.WriteLine(item); 
            }
            db.Trainees.Add(new Trainee { Name = "omar", Id = 7, Age = 5, Address = "suez", Grade = "B", Deptid = 13 });
            db.SaveChanges();
        }
    }
}
