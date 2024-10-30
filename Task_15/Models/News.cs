using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_15.Models
{
    public class News
    { 
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string brief { get; set; }
        public DateTime Dt { get; set; }
        [ForeignKey("category")]
        public int? ctg_id { get; set; }
        [ForeignKey("author")]
        public int? Author_id { get; set; }
        public virtual Author? author { get; set; }
        public virtual Category? category { get; set; }
        public News()
        {
            Dt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id} - {title} - {brief}";
        }

    }
}
