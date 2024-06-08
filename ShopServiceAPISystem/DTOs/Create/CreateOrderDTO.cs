namespace DTOs.Create
{
    public class CreateOrderDTO
    {
        public int? UserId { get; set; }
        public int? PaymentId { get; set; }
        public double? TotalPrice { get; set; }
        public double? FinalPrice { get; set; }
        public int? VoucherId { get; set; }
        public int? ShippingId { get; set; }
    }
}
