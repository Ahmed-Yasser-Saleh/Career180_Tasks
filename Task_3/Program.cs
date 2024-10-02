namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //our System has only one manager
            Manager mg1 = new Manager(1, "ahmed", "ahmed@gmail.com", 23, "01150390086", "male", "Engahmed235", "Manager");
            while (true)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Welcome to Movie Rental Service");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Exit");
                Console.Write("\nChoose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int choice_mg = 0; 
                        while (choice_mg != 4)
                        {
                        Console.WriteLine("Enter your choice");
                        Console.WriteLine("1. Add Employee");
                        Console.WriteLine("2. Delete Employee");
                        Console.WriteLine("3. Display Employees");
                        Console.WriteLine("4. Exit");
                            choice_mg = int.Parse(Console.ReadLine());
                            switch (choice_mg)
                            {
                                case 1:
                                    Console.WriteLine("Enter employee Id ");
                                    int id_em = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter emplyee name ");
                                    string name = Console.ReadLine();
                                    mg1.AddEmployee(
                                        new Employee(id_em, name, "mohamed@gmail.com", 20, "01150390087", "male", "Engahmed235", "Employee"));
                                    break;

                                case 2:
                                    Console.WriteLine("Enter employee Id ");
                                    int Id = int.Parse(Console.ReadLine());
                                    mg1.DeleteEmployee(Id);
                                    break;

                                case 3:
                                    mg1.DisplayEmployees();
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Id ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your password");
                        string pw = Console.ReadLine();
                        int choice_em = 0;
                        while (choice_em != 7)
                        {
                            if (mg1.EmployeeExist(id, pw))
                            {
                                Console.WriteLine("Enter your choice");
                                Console.WriteLine("1. Add Customer");
                                Console.WriteLine("2. Add Movie");
                                Console.WriteLine("3. Rent Movie");
                                Console.WriteLine("4. View Customers");
                                Console.WriteLine("5. View Movies");
                                Console.WriteLine("6. View Rentals");
                                Console.WriteLine("7. Exit");
                                choice_em = int.Parse(Console.ReadLine());
                                switch(choice_em)
                                {
                                    case 1:
                                        mg1.Employees[id - 1].AddCustomer(new Customer(1, "mohamed", "mohamed@gmail.com",26,"01116143997","male","Enhmohamed"
                                            , "Customer"));
                                        break;

                                    case 2:
                                        mg1.Employees[id - 1].AddMovie(new Movie(1, "Robot", "Action", true));
                                        break;
                                     
                                    case 3:
                                        mg1.Employees[id - 1].RentMovie(1, mg1.Employees[id - 1].Movies[0], 1);
                                        break;

                                    case 4:
                                        mg1.Employees[id - 1].DisplayCustomers();
                                        break;

                                    case 5:
                                        mg1.Employees[id - 1].DisplayMovies();
                                        break;

                                    case 6:
                                        mg1.Employees[id - 1].DisplayRentals();
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid Access");
                                break;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Ahmed Yasser Saleh .Net Developer");
                        Console.WriteLine("---------------------------------");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.\n");
                        break;
                }
                }
            }
    }
}
