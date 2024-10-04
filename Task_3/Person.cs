using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Jobtitle { get; set; }

        public Person(int id, string name, string email, int age, string phone, string gender, string password, string jobtitle)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
            Phone = phone;
            Gender = gender;
            Password = password;
            Jobtitle = jobtitle;
        }

    }
}
