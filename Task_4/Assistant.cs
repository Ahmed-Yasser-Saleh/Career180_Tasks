using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Task_4.Doctor;

namespace Task_4
{
    internal class Assistant : Person
    {
        public List<Patient> Patients = new List<Patient>();
        public List<Patient> Waitinglist = new List<Patient>();
        public List<Appointment> Appointments = new List<Appointment>();
        public Assistant(int id, string name, string email, int age, string phone, string gender, string password, string jobtitle)
            : base(id, name, email, age, phone, gender, password, jobtitle)
        {
            
        }
        public void BookAppointment(int id, Doctor doctor, int patient_id, workDay day, TimeOnly time, DateTime dt, double price)
        {
            var patient = Patients.FirstOrDefault(p => p.Id == patient_id);
            if (patient == null)
            {
                Console.WriteLine("There is no patient");
            }
            else
            {
                if (checkavailablity(doctor, day, time))
                {
                    if(!Appointments.Any(app => app.doctor == doctor && app.day == day && app.timeOnly == time))
                    {
                        Appointments.Add(new Appointment(id, doctor, patient, day, time, dt, price));
                        Console.WriteLine("appointment has been booked");
                    }
                    else
                    {
                            Console.WriteLine("this date is already booked");
                    }
                }
                else
                {
                    Console.WriteLine("this date is not available");
                }
            }
        }
        public bool checkavailablity(Doctor doctor, workDay day, TimeOnly time)
        {
            if (doctor.workschedule.ContainsKey(day))
            {
                foreach(var i in doctor.workschedule[day])
                {
                    if (time == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void DeleteAppointment(int id)
        {
            var appointment = Appointments.FirstOrDefault(p => p.Id == id);
            if (appointment != null)
            {
                Appointments.Remove(appointment);
            }
            else
            {
                Console.WriteLine($"There is no appointment with id: {id}");
            }
            
        }
        public void AddPatient(Patient pt)
        {
            if (Patients.Any(e => e.Id == pt.Id))
            {
                Console.WriteLine($"Error: An Patient with ID {pt.Id} already exists.");
                return;
            }
            Patients.Add(pt);
            Console.WriteLine($"Patient {pt.Name} has been added");
        }
        public void DeletePatient(int id)
        {
            foreach (Patient pt in Patients)
            {
                if (pt.Id == id)
                {
                    Patients.Remove(pt);
                    Console.WriteLine($"Patient {pt.Name} has been deleted");
                    break;
                }
            }
        }
        public void AddPatientWait(int id)
        {
            foreach (Patient pt in Patients)
            {
                if (pt.Id == id)
                {
                    Waitinglist.Add(pt);
                    Console.WriteLine($"Patient {pt.Name} has been added");
                    break;
                }
            } 
        }
        public void RemovePatientWait(int id)
        {
            foreach (Patient pt in Patients)
            {
                if (pt.Id == id)
                {
                    Waitinglist.Remove(pt);
                    Console.WriteLine($"Patient {pt.Name} has been removed");
                    break;
                }
            }
        }
        public void DisplayWaitinglist()
        {
            foreach (Patient wt in Waitinglist)
            {
                Console.WriteLine(wt);
            }
        }
        public void DisplayBookedAppointment()
        {
            if (Appointments.Count != 0)
            {
                foreach (Appointment ap in Appointments)
                {
                    Console.WriteLine(ap);
                }
            }
            else
            {
                Console.WriteLine("There is no booked appointment");
            }
        }
        public override string ToString()
        {
            return $"Jobtitle: {Jobtitle}, ID: {Id}, Name: {Name}";
        }
    }
}
