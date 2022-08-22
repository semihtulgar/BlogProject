namespace BlogProject.Models.ViewModels
{
    public class PostViewModel
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string? PhotoName { get; set; }
        public Category? Category { get; set; }

    }
}
