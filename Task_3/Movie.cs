using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_3
{
    internal class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public bool availability { get; set; }
        public Movie(int id, string title, string genre, bool availability)
        {
            this.id = id;
            this.title = title;
            this.genre = genre;
            this.availability = availability;
        }
        public override string ToString()
        {
            return $"title: {title}, genre: {genre}, availability: {availability}";
        }
    }
}
