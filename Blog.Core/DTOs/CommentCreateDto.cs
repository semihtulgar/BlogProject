using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CommentCreateDto
    {
        public string CommentText { get; set; }
        public int PostId { get; set; }
    }
}
