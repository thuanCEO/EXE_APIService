using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
