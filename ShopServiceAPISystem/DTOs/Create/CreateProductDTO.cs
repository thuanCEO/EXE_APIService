using Microsoft.AspNetCore.Http;

namespace DTOs.Create
{
    public class CreateProductDTO
    {
        public string Title { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
