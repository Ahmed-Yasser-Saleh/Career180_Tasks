using static Task_4.Doctor;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor(1, "Dr. Ahmed", "email", 45, "555-1234", "Male", "12345", "Doctor", "bones");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to Clinic Service");
            Console.WriteLine("--------------------------------");

            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Doctor Menu");
                Console.WriteLine("2. Assistant Menu");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DoctorMenu(doctor);
                        break;
                    case "2":
                        AssistantMenu(doctor);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DoctorMenu(Doctor doctor)
        {
            Console.WriteLine("Enter Your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            bool doctorMenuRunning = true;
            if (!doctor.login(email, password))
            {
                Console.WriteLine("Invalid Login");
                doctorMenuRunning = false;
            }
            while (doctorMenuRunning)
            {
                Console.WriteLine("\n--- Doctor Menu ---");
                Console.WriteLine("1. Set WorkShedule");
                Console.WriteLine("2. Get WorkShedule");
                Console.WriteLine("2. Display Assistants");
                Console.WriteLine("3. Add Assistant");
                Console.WriteLine("4. Delete Assistant");
                Console.WriteLine("5. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                       Dictionary<workDay, List<TimeOnly>> dic = new Dictionary<workDay, List<TimeOnly>>();
                        foreach (workDay day in Enum.GetValues(typeof(workDay)))
                        {
                            dic.Add(day, new List<TimeOnly>
                            {
                                new TimeOnly(20, 00),
                                new TimeOnly(20, 15),
                                new TimeOnly(20, 30),
                                new TimeOnly(20, 45),
                                new TimeOnly(21, 00),
                                new TimeOnly(21, 15),
                                new TimeOnly(21, 30)
                            });
                        }
                        doctor.set_workschedule(dic);
                        break;
                    case "2":
                        Dictionary<workDay, List<TimeOnly>> dic2 = doctor.get_workschedule();
                        foreach(var i in dic2)
                        {
                            Console.WriteLine($"Day: {i.Key}");
                            foreach(var j in i.Value)
                            {
                                Console.WriteLine($"Time: {j}");
                            }
                            Console.WriteLine("\n");
                        }
                        break;
                    case "3":
                        doctor.DisplayAssistants();
                        break;
                    case "4":
                        Console.Write("Enter Assistant ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Assistant Name: ");
                        string name = Console.ReadLine();
                        Assistant newAssistant = new Assistant(id, name, "email", 30, "phone", "gender", "12345", "Assistant");
                        doctor.AddAssistant(newAssistant);
                        break;
                    case "5":
                        Console.Write("Enter Assistant ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        doctor.DeleteAssistant(deleteId);
                        break;
                    case "6":
                        doctorMenuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AssistantMenu(Doctor doctor)
        {
            Console.WriteLine("Enter Your id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            bool assistantMenuRunning = true;
            if (!doctor.Assistants[id - 1].login(email, password))
            {
                Console.WriteLine("Invalid Login");
                assistantMenuRunning = false;
            }
            
            while (assistantMenuRunning)
            {
                Console.WriteLine("\n--- Assistant Menu ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Delete Patient");
                Console.WriteLine("3. Book Appointment");
                Console.WriteLine("4. Display Waiting List");
                Console.WriteLine("5. Display Booked Appointments");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Patient ID: ");
                        int Id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Patient Name: ");
                        string name = Console.ReadLine();
                        Patient newPatient = new Patient(Id, name, "email", 25, "phone", "gender", "12345", "Patient", doctor);
                        doctor.Assistants[id - 1].AddPatient(newPatient);
                        break;
                    case "2":
                        Console.Write("Enter Patient ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        doctor.Assistants[id - 1].DeletePatient(deleteId);
                        break;
                    case "3":
                        Console.Write("Enter Appointment ID: ");
                        int appointmentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Patient ID: ");
                        int patientId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
                        DateOnly date = DateOnly.Parse(Console.ReadLine());
                        Console.Write("Enter Appointment Time (hh:mm): ");
                        TimeOnly time = TimeOnly.Parse(Console.ReadLine());
                         doctor.Assistants[id - 1].BookAppointment(appointmentId, doctor, patientId, date, time, DateTime.Now, 100.0);
                        break;
                    case "4":
                        doctor.Assistants[id - 1].DisplayWaitinglist();
                        break;
                    case "5":
                        doctor.Assistants[id - 1].DisplayBookedAppointment();
                        break;
                    case "6":
                        assistantMenuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
