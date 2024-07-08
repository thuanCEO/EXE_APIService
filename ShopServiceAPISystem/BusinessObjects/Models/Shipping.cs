using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public double? ShipFee { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
