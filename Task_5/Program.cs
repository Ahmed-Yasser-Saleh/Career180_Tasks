using System.Diagnostics;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            employee[] Emparr =
            {
                new employee(123, "ahmed", Gender.Male, new Hiring_date(2024,7,15)),
                new employee(124, "mohamed", Gender.Male, new Hiring_date(2024,6,15)),
                new employee(125, "omnia", Gender.Female, new Hiring_date(2024,6,5)),
                new employee(126, "osamaa", Gender.Male, new Hiring_date(2023,6,5))
            };

            //use Bubble sort algorithm
            int size = Emparr.Length;
            bool swapped = false;
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size - 1 - i; j++)
                {
                    if (Emparr[j].hiring.Year > Emparr[j + 1].hiring.Year)
                    {
                        swap(Emparr, j, j + 1);
                        swapped = true;
                    }
                    else if(Emparr[j].hiring.Year == Emparr[j + 1].hiring.Year)
                    {
                        if (Emparr[j].hiring.Month > Emparr[j + 1].hiring.Month)
                        {
                            swap(Emparr, j, j + 1);
                            swapped = true;
                        }
                        else if(Emparr[j].hiring.Month == Emparr[j + 1].hiring.Month)
                        {
                            if (Emparr[j].hiring.Day > Emparr[j + 1].hiring.Day)
                            {
                                swap(Emparr, j, j + 1);
                                swapped = true;
                            }
                        }
                    }
                }
                if (!swapped)
                    break;
            }
            for(int i = 0; i < size;i++)
            {
                Console.WriteLine(Emparr[i]);
            }

        }
        public static void swap(employee[] employess, int index, int index2) {
            employee temp = employess[index];
            employess[index] = employess[index2];
            employess[index2] = temp;
        }
    }
    class employee
    {
        private int ID;
        private string Name;
        private Gender Gend;
        private Hiring_date Hiring;
        public employee(int ID, string Name, Gender Gend, Hiring_date Hiring)
        {
            this.ID = ID;
            this.Name = Name;
            this.Gend = Gend;
            this.Hiring = Hiring;
        }
        public int id
        {
            get => ID;
            set
            {
                this.ID = value;
            }
        }
        public string name
        {
            get => Name;
            set
            {
                this.Name = value;
            }
        }
        public Gender gend
        {
            get => Gend;
            set
            {
                this.Gend = value;
            }
        }
        public Hiring_date hiring
        {
            get => Hiring;
            set
            {
                this.Hiring = value;
            }
        }
        public override string ToString()
        {
            return $"emp_name: {name}\n" +
                   $"emp_id: {id}\n" +
                   $"emp_gender: {Gend}\n" +
                   $"{Hiring.Year}/{Hiring.Month}/{Hiring.Day}\n";
        }
    }
    enum Gender
    {
        Male,
        Female
    }
    struct Hiring_date
    {
        private int year;
        private int month;
        private int day;
        public Hiring_date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public int Year
        {
            get => year;
            set
            {
                this.year = value;
            }
        }
        public int Month
        {
            get => month;
            set
            {
                this.month = value;
            }
        }
        public int Day
        {
            get => day;
            set
            {
                this.day = value;
            }
        }

        public override string ToString()
        {
            return $"{year}/{month}/{day}";
        }
    }

}