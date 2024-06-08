namespace DTOs.Update
{
    public class UpdateProductDTO
    {
        public string Title { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
