namespace BlogProject.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PhotoName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
