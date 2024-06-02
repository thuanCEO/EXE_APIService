using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Carts
{
    public class ResponseCartDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string FullName { get; set; }
        public int? Status { get; set; }
    }
}
