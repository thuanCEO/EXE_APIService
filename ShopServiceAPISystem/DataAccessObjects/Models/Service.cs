using System;
using System.Collections.Generic;

namespace DataAccessObjects.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
