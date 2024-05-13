namespace BusinessObjects.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        public int? Status { get; set; }
        public int? ServiceId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Service Service { get; set; }
    }
}
