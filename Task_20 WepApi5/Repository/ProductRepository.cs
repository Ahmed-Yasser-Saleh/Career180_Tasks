using Task_20_WepApi5.Models;

namespace Task_20_WepApi5.Repository
{
    public class ProductRepository: GenericRepository<Product>
    {
        public ProductRepository(ProductContext db) : base(db) { }
        
        public Product GetByPrice(decimal price)
        {
            var x = db.Product.Where(x => x.Price == price).FirstOrDefault();
            if (x == null)
            {
                return null;
            }
            return x;
        }
    }
}
