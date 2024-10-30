using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_15.Models;

namespace Task_15.MyContex
{
    public class NewsContext : DbContext
    {
        public NewsContext()
        {
            
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-M284REV\\SQLEXPRESS;Database=LearnIt_Task;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
