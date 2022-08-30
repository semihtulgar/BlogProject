using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostCreateDto
    {
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PhotoName { get; set; }
        public int CategoryId { get; set; }
    }
}
