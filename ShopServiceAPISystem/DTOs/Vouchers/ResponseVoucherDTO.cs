using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.vouchers
{
    public class ResponseVoucherDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public int? Status { get; set; }
    }
}
