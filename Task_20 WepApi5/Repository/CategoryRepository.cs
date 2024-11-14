using Task_20_WepApi5.Models;

namespace Task_20_WepApi5.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ProductContext db):base(db)
        {
            
        }
        public bool CheckId(int id)
        {
            var x = db.Category.Any(c => c.id == id);
            return x;
        }
    }
}
