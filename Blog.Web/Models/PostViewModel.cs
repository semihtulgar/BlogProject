namespace Blog.Web.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PhotoName { get; set; }
        public int CategoryId { get; set; }
    }
}
