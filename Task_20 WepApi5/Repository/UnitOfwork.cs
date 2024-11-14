using Task_20_WepApi5.Models;

namespace Task_20_WepApi5.Repository
{
    public class UnitOfwork
    {
        ProductContext db;
        GenericRepository<Product> Pdrepos;
        GenericRepository<Category> Ctgrepos;
        ProductRepository Productrepository;
        CategoryRepository CategoryRepository;
        public UnitOfwork(ProductContext db)
        {
            this.db = db;
        }
        public GenericRepository<Product> pdrepos
        {
            get
            {
                if (Pdrepos == null)
                {
                    Pdrepos = new GenericRepository<Product>(db);
                }
                return Pdrepos;
            }
        }
        public GenericRepository<Category> ctgrepos
        {
            get
            {
                if (Ctgrepos == null)
                {
                    Ctgrepos = new GenericRepository<Category>(db);
                }
                return Ctgrepos;
            }
        }
        public ProductRepository pdrproductrepositoryepos
        {
            get
            {
                if (Productrepository == null)
                {
                    Productrepository = new ProductRepository(db);
                }
                return Productrepository;
            }
        }
        public CategoryRepository categoryRepository
        {
            get
            {
                if (CategoryRepository == null)
                {
                    CategoryRepository = new CategoryRepository(db);
                }
                return CategoryRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
