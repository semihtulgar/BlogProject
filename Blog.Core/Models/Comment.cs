using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
