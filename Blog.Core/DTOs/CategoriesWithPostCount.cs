using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CategoriesWithPostCount
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<PostDto> Posts { get; set; }
    }

}
