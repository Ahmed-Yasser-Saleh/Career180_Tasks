

namespace Task_20_WebApi5.DTO
{
    public class CategoryDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public virtual List<string> productsName { get; set; } = new List<string>();
    }
}
