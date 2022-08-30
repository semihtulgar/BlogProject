using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostInDetailDto : PostDto
    {
        public List<CommentDto> Comments { get; set; }
        public CategoryDto Category { get; set; }
    }
}
