using System.ComponentModel.DataAnnotations.Schema;

namespace Task_19_WebApi4.Model
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public virtual List<Product> products { get; set; } = new List<Product>();
    }
}
