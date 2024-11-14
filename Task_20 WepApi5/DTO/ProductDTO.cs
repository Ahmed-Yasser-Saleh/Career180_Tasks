namespace Task_20_WebApi5.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string? image { get; set; }
        public int CategoryId { get; set; }
        public string  CategoryName { get; set; }
    }
}
