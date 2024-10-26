using System.IO;
using System.Net.Mail;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1, y1, z1, x2, y2, z2;
            #region using parse
            //try
            //{
            //    Console.WriteLine("Please, Enter the x coordinate for point1");
            //    x1 = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the y coordinate for point1");
            //    y1 = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the z coordinate for point1");
            //    z1 = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the x coordinate for point2");
            //    x2 = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the y coordinate for point2");
            //    y2 = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the z coordinate for point2");
            //    z2 = double.Parse(Console.ReadLine());
            //    point_3d a = new point_3d(x1, y1, z1);
            //    point_3d b = new point_3d(x2, y2, z2);
            //}
            //catch (Exception e) {
            //    using (var fs = File.AppendText("Log File Exceptions"))   //using for dispose manage and unmanage code
            //    {
            //        fs.WriteLine($"- {e.Message}- {e.TargetSite}- Date:{DateTime.Now}");
            //    }
            //}
            #endregion
            #region using Tryparse
            //try
            //{
            //    Console.WriteLine("Please, Enter the x coordinate for point1");
            //    if(!double.TryParse(Console.ReadLine(), out x1))
            //        throw new Exception($"The input string for x1 was not in a correct format");
            //    Console.WriteLine("Please, Enter the y coordinate for point1");
            //    if(!double.TryParse(Console.ReadLine(), out y1))
            //        throw new Exception($"The input string for y1 was not in a correct format");
            //    Console.WriteLine("Please, Enter the z coordinate for point1");
            //    if(!double.TryParse(Console.ReadLine(), out z1))
            //        throw new Exception($"The input string for z1 was not in a correct format");
            //    Console.WriteLine("Please, Enter the x coordinate for point2");
            //    if(!double.TryParse(Console.ReadLine(), out x2))
            //        throw new Exception($"The input string for x2 was not in a correct format");
            //    Console.WriteLine("Please, Enter the y coordinate for point2");
            //    if(!double.TryParse(Console.ReadLine(), out y2))
            //        throw new Exception($"The input string for y2 was not in a correct format");
            //    Console.WriteLine("Please, Enter the z coordinate for point2");
            //    if(!double.TryParse(Console.ReadLine(), out z2))
            //        throw new Exception($"The input string for z2 was not in a correct format");
            //    point_3d a = new point_3d(x1, y1, z1);
            //    point_3d b = new point_3d(x2, y2, z2);
            //    Console.WriteLine(a);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    using (var fs = File.AppendText("Log File Exceptions"))   //using for dispose manage and unmanage code
            //    {
            //        fs.WriteLine($"- {e.Message}- {e.TargetSite}- Date:{DateTime.Now}");
            //    }
            //}
            #endregion
            #region using Convert
            //try
            //{
            //    Console.WriteLine("Please, Enter the x coordinate for point1");
            //    x1 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the y coordinate for point1");
            //    y1 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the z coordinate for point1");
            //    z1 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the x coordinate for point2");
            //    x2 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the y coordinate for point2");
            //    y2 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Please, Enter the z coordinate for point2");
            //    z2 = Convert.ToDouble(Console.ReadLine());
            //    point_3d a = new point_3d(x1, y1, z1);
            //    point_3d b = new point_3d(x2, y2, z2);
            //    Console.WriteLine(a);
            //}
            //catch (Exception e)
            //{
            //    using (var fs = File.AppendText("Log File Exceptions"))   //using for dispose manage and unmanage code
            //    {
            //        fs.WriteLine($"- {e.Message}- {e.TargetSite}- Date:{DateTime.Now}");
            //    }
            //}
            #endregion
            #region SingleTone
            var nic = NIC_Card.get_NIC_card("Intel", "00-14-22-01-23-45", NICType.Ethernet);
            var nic2 = NIC_Card.get_NIC_card("ahmed", "00-14-22-01-23-45", NICType.Ethernet); //will not create this instance
            Console.WriteLine(nic); 
            Console.WriteLine(nic2); // it will be the same 
            #endregion
        }
    }
    public class NIC_Card
    {
        public string Manufacturer { get; set; }
        public string MACAddress { get; set; }
        public NICType Type { get; set; }

        private static NIC_Card nic_card;
        private NIC_Card(string manufacturer, string macAddress, NICType type)
        {
            Manufacturer = manufacturer;
            MACAddress = macAddress;
            Type = type;
        }
        public static NIC_Card get_NIC_card(string manufacturer, string macAddress, NICType type)
        {
           if(nic_card == null)
            {
                nic_card = new NIC_Card(manufacturer, macAddress, type);
            }
            return nic_card;

        }
        public override string ToString()
        {
            return $"Manufacture: {Manufacturer}, MAC_Address: {MACAddress}, Type:{Type}";
        }
    }
    public enum NICType
    {
        Ethernet,
        TokenRing
    }

}
