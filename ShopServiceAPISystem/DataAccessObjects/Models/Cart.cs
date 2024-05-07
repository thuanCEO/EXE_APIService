using System;
using System.Collections.Generic;

namespace DataAccessObjects.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
