using System;
namespace Task_2
{
    class Program
    {
        static int std_num = 6;
        static int sub_num = 4;
        static int[,] std_sub = new int[std_num, sub_num];
        public static void Main()
        {
            for(int i = 0; i < std_num; i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Student with id {i + 1}");
                Console.WriteLine("-------------------------");
                int sum_garde = 0;
                int c = 0;
                for (int j = 0; j < sub_num; j++)
                {   
                    Console.WriteLine($"Enter the grade of subject {j + 1}");
                    int grade = int.Parse(Console.ReadLine());
                    std_sub[i, j] = grade;
                    sum_garde += grade;
                    if (!fail_garde(grade))
                    {
                        c++;
                    }
                }
                if (c > 2)
                {
                    Console.WriteLine($"this student with id {i + 1} faild in more than two subjects");
                }
            }
        }
        public static bool fail_garde(int std_grade){
        return (std_grade >= 50);
        }

    }
  

}