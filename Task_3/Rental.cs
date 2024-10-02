using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Rental
    {
        public int Id { get; set; }
        public Movie RentedMovie { get; set; }
        public Customer RentingCustomer { get; set; }
        public DateTime RentalDate { get; set; }

        public Rental(int id, Movie movie, Customer customer)
        {
            Id = id;
            RentedMovie = movie;
            RentingCustomer = customer;
            RentalDate = DateTime.Now;
            RentedMovie.availability = false;  
        }

        public override string ToString()
        {
            return $"Rental ID: {Id}, Movie: {RentedMovie.title}, Customer: {RentingCustomer.Name}, Date: {RentalDate}";
        }
    }
}
