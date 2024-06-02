using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.shippings
{
    public class ResponseShippingDTO
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public double? ShipFee { get; set; }
        public int? Status { get; set; }
    }
}
