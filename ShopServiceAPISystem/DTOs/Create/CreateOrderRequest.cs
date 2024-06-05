using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Create
{
    public class CreateOrderRequest
    {
        public CreateOrderDTO OrderDTO { get; set; }
        public List<CreateOrderDetailDTO> OrderDetailDTO { get; set; }
    }
}
