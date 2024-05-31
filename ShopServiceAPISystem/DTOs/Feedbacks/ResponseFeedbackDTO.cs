using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Feedbacks
{
    public class ResponseFeedbackDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string FullName { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
