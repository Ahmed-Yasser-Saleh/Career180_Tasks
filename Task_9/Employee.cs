using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public Employee(int id, string name, int age, string phone, string gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Gender = gender;
        }
        public event Action<Employee> myEvent;
        public void invokeaddemployee(Employee e)
        {
            if(myEvent != null)
                myEvent(e); // == myEvent.Invoke(e);
            else
                Console.WriteLine("Event do not reference to any method");
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
