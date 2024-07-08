﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }

        public virtual User User { get; set; }
    }
}
