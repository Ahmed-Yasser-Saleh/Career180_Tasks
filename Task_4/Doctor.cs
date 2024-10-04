using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Doctor: Person
    {
        string Department {  get; set; }
        public List<Assistant> Assistants { get; set; } = new List<Assistant>();
        public Dictionary<DateOnly, TimeOnly> workschedule = new Dictionary<DateOnly, TimeOnly>();
        public Doctor(int id, string name, string email, int age, string phone, string gender, string password, string jobtitle, string department)
            : base(id, name, email, age, phone, gender, password, jobtitle)
        {
            Department = department;
        }
        public void AddAssistant(Assistant ass)
        {
            if (Assistants.Any(e => e.Id == ass.Id))
            {
                Console.WriteLine($"Error: An assistant with ID {ass.Id} already exists.");
                return;
            }
            Assistants.Add(ass);
            Console.WriteLine($"Assistant {ass.Name} has been added");
        }
        public void DeleteAssistant(int id)
        {
            foreach (Assistant ass in Assistants)
            {
                if (ass.Id == id)
                {
                    Assistants.Remove(ass);
                    Console.WriteLine($"Assistant {ass.Name} has been deleted");
                    break;
                }
            }
        }
        public void DisplayAssistants()
        {
            foreach(Assistant ass in Assistants)
            {
                Console.WriteLine(ass);
            }
        }
        public override string ToString()
        {
            return $"Jobtitle: {Jobtitle}, ID: {Id}, Name: {Name}";
        }
    }
}
