using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Patient: Person
    {
        public Doctor doctor { get; set; }
        public Patient(int id, string name, string email, int age, string phone, string gender, string password, string jobtitle, Doctor dc) 
            : base(id, name, email, age, phone, gender, password, jobtitle)
        {
            doctor = dc;
        }
        public override string ToString()
        {
            return $"Jobtitle: {Jobtitle}, ID: {Id}, Name: {Name}";
        }
    }
}
