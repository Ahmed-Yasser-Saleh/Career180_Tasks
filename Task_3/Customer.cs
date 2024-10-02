using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Customer : Person
    {
        public string Jobtitle { get; set; }
        public Customer(int id, string name, string email, int age, string phone, string gender, string Password, string jobtitle) : base(id, name, email, age, phone, gender, Password)
        {
            Jobtitle = jobtitle;
        }
        public override string ToString()
        {
            return $"Jobtitle: {Jobtitle}, ID: {Id}, Name: {Name}";
        }
    }
}
