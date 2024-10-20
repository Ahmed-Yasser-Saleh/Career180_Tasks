namespace Task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Employee(1, "Ahmed", 23, "01150390086", "Male");
            var c1 = new Club("Zamalek","Mohandessen");
            var sc1 = new SocialEnsurance("191000");
            e1.myEvent += c1.Addtoclub;
            e1.myEvent += sc1.addEmployee;
            e1.invokeaddemployee(e1); //trigger The event
        }
    }
}
