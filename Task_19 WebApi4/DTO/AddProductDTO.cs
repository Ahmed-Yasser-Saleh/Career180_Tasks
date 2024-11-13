namespace Task_19_WebApi4.DTO
{
    public class AddProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public IFormFile image { get; set; }
        public int CategoryId { get; set; }
    }
}
