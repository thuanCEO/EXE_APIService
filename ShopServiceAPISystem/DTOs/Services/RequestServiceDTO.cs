using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Services
{
    public class RequestServiceDTO
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }
    }
}
