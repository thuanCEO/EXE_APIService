using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Categories
{
    public class RequestCategoryDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
