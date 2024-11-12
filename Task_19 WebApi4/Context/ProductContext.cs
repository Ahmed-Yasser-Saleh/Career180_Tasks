using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Task_19_WebApi4.Model;

namespace Task_19_WebApi4.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
        {
            
        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
    }
}
