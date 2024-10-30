using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_15.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string brief { get; set; }
        public virtual List<News> news { get; set; } = new List<News>();
        public override string ToString()
        {
            return $"{Id} - {Name} - {brief}";
        }
    }
}
