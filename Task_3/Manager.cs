using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Manager : Person
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Manager(int id, string name, string email, int age, string phone, string gender, string password, string jobtitle) : base(id, name, email, age, phone, gender, password, jobtitle)
        {
           
        }
        public void AddEmployee(Employee employee)
        {
            if (Employees.Any(e => e.Id == employee.Id))
            {
                Console.WriteLine($"Error: An employee with ID {employee.Id} already exists.");
                return;
            }
            Employees.Add(employee);
            Console.WriteLine($"Employee {employee.Name} has been added");
        }
        public void DeleteEmployee(int id)
        {
            foreach(Employee emp in Employees)
            {
                if(emp.Id == id)
                {
                    Employees.Remove(emp);
                    Console.WriteLine($"Employee {emp.Name} has been deleted");
                    break;
                }
            }
        }
        public bool EmployeeExist(int id, string password)
        {
            foreach (Employee emp in Employees)
            {
                if(id == emp.Id && password == emp.Password)
                    return true;
            }
            return false;
        }
        public void DisplayEmployees()
        {
            if (Employees.Count > 0)
            {
                foreach (Employee emp in Employees)
                    Console.WriteLine(emp);
            }
            else
            {
                Console.WriteLine("There are No Employees to display");
            }
        }
        public override string ToString()
        {
            return $"Jobtitle: {Jobtitle}, ID: {Id}, Name: {Name}";
        }
    }
}
