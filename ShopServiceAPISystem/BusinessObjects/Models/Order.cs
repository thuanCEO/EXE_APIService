using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PaymentId { get; set; }
        public double? TotalPrice { get; set; }
        public double? FinalPrice { get; set; }
        public int? VoucherId { get; set; }
        public int? ShippingId { get; set; }
        public int? Status { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual User User { get; set; }
        public virtual Voucher Voucher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
