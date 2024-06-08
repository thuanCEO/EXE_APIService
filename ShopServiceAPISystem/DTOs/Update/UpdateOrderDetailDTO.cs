namespace DTOs.Update
{
    public class UpdateOrderDetailDTO
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        public int? Status { get; set; }
        public int? ServiceId { get; set; }
    }
}
