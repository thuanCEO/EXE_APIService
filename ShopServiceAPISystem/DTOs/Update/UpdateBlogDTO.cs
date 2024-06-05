using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Update
{
    public class UpdateBlogDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
    }
}
