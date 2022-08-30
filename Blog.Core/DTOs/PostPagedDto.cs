﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostPagedDto
    {
        public List<PostDto> Posts { get; set; }
        public int TotalCount { get; set; }
    }
}
