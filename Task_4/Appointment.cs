using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Appointment
    {
        public int Id { get; set; }
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
        public DateOnly dateOnly { get; set; }
        public TimeOnly timeOnly { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }
        public Appointment(int id, Doctor doctor, Patient patient, DateOnly dt, TimeOnly time, DateTime date, double Price)
        { 
          Id = id;
          this.patient = patient;
          this.doctor = doctor;
          dateOnly = dt;
          timeOnly = time;
          this.date = date;
          price = Price;
        }
        public override string ToString()
        {
          return  $"patien Name: {patient.Name}, Doctor: {doctor.Name}, Time: {date}, date_appointment: {dateOnly}, Time_appointment: {timeOnly}, price: {price}";
        }
    }
}
