using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    internal class SocialEnsurance
    {
        public string InsuranceNumber { get; set; }
        public DateTime StartDate { get; set; }
        public SocialEnsurance(string insuranceNumber)
        {
            InsuranceNumber = insuranceNumber;
            StartDate = DateTime.Now;
        }
        public void addEmployee(Employee e)
        {
            if(e !=  null) 
              Console.WriteLine($"Employee:{e} Added to SocialEnsurance has {this}");
            else
                Console.WriteLine("Event do not reference to any method");
        }
        public override string ToString()
        {
            return $"InsuranceNumber: {InsuranceNumber}  with StartDate: {StartDate}";
        }
    }
    
}
