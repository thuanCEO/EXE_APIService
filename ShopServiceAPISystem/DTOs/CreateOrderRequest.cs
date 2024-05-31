using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CreateOrderRequest
    {
        public OrderDTO OrderDTO { get; set; }
        public List<OrderDetailDTO> OrderDetailDTO { get; set; }
    }
}
