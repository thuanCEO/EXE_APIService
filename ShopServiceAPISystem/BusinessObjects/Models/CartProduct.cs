using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class CartProduct
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
