using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Employee : Person
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        public Employee(int id, string name, string email, int age, string phone, string gender, string password, string jobtitle) : base( id, name, email,  age,  phone,  gender, password,  jobtitle)
        {

        }

        public void AddMovie(Movie movie)
        {
            if (Movies.Any(mv => mv.id == movie.id))
            {
                Console.WriteLine($"Error: An movie with ID {movie.id} already exists.");
                return;
            }
            Movies.Add(movie);
            Console.WriteLine($"movie {movie.title} has been added");
        }
        public void DeleteMovie(int id)
        {
            foreach (Movie mv in Movies)
            {
                if (mv.id == id)
                {
                    Movies.Remove(mv);
                    Console.WriteLine($"Movie {mv.title} has been deleted");
                    break;
                }
            }
        }
        public void DisplayMovies()
        {
            foreach (Movie mv in Movies)
                Console.WriteLine(mv);
        }
        public void AddCustomer(Customer customer)
        {
            if (Customers.Any(cs => cs.Id == customer.Id))
            {
                Console.WriteLine($"Error: An customer with ID {customer.Id} already exists.");
                return;
            }
            Customers.Add(customer);
            Console.WriteLine($"Customer {customer.Name} has been added");
        }
        public void DeleteCustomer(int id)
        {
            foreach (Customer cs in Customers)
            {
                if (cs.Id == id)
                {
                    Customers.Remove(cs);
                    Console.WriteLine($"Customer {cs.Name} has been deleted");
                    break;
                }
            }
        }
        public void DisplayCustomers()
        {
            foreach (Customer cs in Customers)
                Console.WriteLine(cs);
        }
        public void RentMovie(int id, Movie movie, int id_customer)
        {
            if (Rentals.Any(rt => rt.Id == id))
            {
                Console.WriteLine($"Error: the movie is not available");
                return;
            }
            foreach (Customer cs in Customers)
            {
                if (cs.Id == id)
                {
                    if (movie.availability)
                    {
                        Rentals.Add(new Rental(id, movie, cs));
                        Console.WriteLine($"movie: {movie.title} has been rented by customer: {cs.Name} at {DateTime.Now}");
                    }
                    break;
                }
            }
            
        }
        public void movieavailability(Movie movie, bool state)
        {
            movie.availability = state;
        }

        public void DisplayRentals()
        {
            foreach (Rental rt in Rentals)
                Console.WriteLine(rt);
        }
        public override string ToString()
        {
            return $"Jobtitle: {Jobtitle}, ID: {Id}, Name: {Name}";
        }
    }
}
