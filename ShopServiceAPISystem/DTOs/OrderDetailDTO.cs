using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrderDetailDTO
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
    }
}
