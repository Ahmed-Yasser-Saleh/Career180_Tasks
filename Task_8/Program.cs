namespace Task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Question, List<Answer>> myquestion = new Dictionary<Question, List<Answer>>()
            {
                { new Question("Which is not vegetable",2),new List<Answer>()
                    { 
                      new Answer(1, "Apple"),
                      new Answer(2, "Car"),
                      new Answer(3, "orange"),
                      new Answer(4, "banana")
                    }
                },  

                { new Question("Which is not color"),new List<Answer>()
                   {
                     new Answer(1, "Blue"),
                     new Answer(2, "Red"),
                     new Answer(3, "orange"),
                     new Answer(4, "ahmed")
                   } 
                }
            };
            foreach (var question in myquestion.Keys)
            {
                Console.WriteLine(question);
                foreach (var answer in myquestion[question])
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine();
            }
        }
    }
    public class Question
    {
        public string question { get; set; }
        public int mark { get; set; }
        public Question(string Question, int Mark = 1)
        {
            question = Question;
            mark = Mark;
        }
        public override string ToString()
        {
            return $"{question}                     {mark} marks";
        }
    }
    public class Answer
    {
        public int num { get; set;}
        public string  choose { get; set; }
        public Answer(int Num, string Choose) {
            num = Num;
            choose = Choose;
        }
        public override string ToString()
        {
            return $"{num}. {choose}";
        }
    }
}
