using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Cartproducts
{
    public class ResponseCartProductDTO
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }

    }
}
