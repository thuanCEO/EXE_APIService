namespace DTOs.Update
{
    public class UpdateOrderDTO
    {
        public int? UserId { get; set; }
        public int? PaymentId { get; set; }
        public double? TotalPrice { get; set; }
        public double? FinalPrice { get; set; }
        public string Address { get; set; }
        public int? VoucherId { get; set; }
        public int? ShippingId { get; set; }
        public int? Status { get; set; }
    }
}
