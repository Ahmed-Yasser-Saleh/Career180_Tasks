using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    internal class Club
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Club(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public void Addtoclub(Employee e)
        {
            if (e != null)
            {
                Employees.Add(e);
                Console.WriteLine($"Employee:{e} Added to club: {this}");
            }
            else
                Console.WriteLine("Process faild, Please try again!!");
        }
        public void displayeEmployee()
        {
            foreach (Employee e in Employees)
            {
                Console.WriteLine(e);
            }
        }
        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}";
        }
    }
}
