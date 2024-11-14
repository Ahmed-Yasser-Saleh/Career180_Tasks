using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task_20_WepApi5.Models;

namespace Task_20_WepApi5.Repository
{
    public class GenericRepository<T> where T : class //to have features of class
    {
        protected ProductContext db;
        public GenericRepository(ProductContext db)
        {
            this.db = db;
        }
        public List<T> Selectall()
        {
            return db.Set<T>().ToList();
        }  
        public T GetById(int id)
        {
            var x = db.Set<T>().Find(id);
            if(x == null)
            {
                return null;
            }
            return x;
        }
        public void Add(T Entity)
        {
            db.Set<T>().Add(Entity);
        }
        public void Delete(T Entity)
        {
            db.Set<T>().Remove(Entity);
        }
        public void Edit(T Entity) {
            db.Update(Entity);
        }
    }
}
