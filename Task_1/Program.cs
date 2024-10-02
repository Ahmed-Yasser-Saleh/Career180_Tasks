namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                int num1, num2;
                double Result;
                num1 = int.Parse(Console.ReadLine());
                num2 = int.Parse(Console.ReadLine());
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Result = num1 + num2;
                        Console.WriteLine($"{num1} + {num2} = {Result}");
                        break;
                    case 2:
                        Result = num1 - num2;
                        Console.WriteLine($"{num1} - {num2} = {Result}");
                        break;
                    case 3:
                        Result = num1 * num2;
                        Console.WriteLine($"{num1} * {num2} = {Result}");
                        break;
                    case 4:
                        try
                        {
                            Result = num1 / num2;
                            Console.WriteLine($"{num1} + {num2} = {Result}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            } while (choice != 0);

        }
    }
}
