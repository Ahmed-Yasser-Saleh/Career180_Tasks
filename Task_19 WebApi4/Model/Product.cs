using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Task_19_WebApi4.Model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string? image { get; set; } 
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? category { get; set; }
    }
}
