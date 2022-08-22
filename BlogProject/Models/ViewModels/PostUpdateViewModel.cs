using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models.ViewModels
{
    public class PostUpdateViewModel
    {
        public int PostID { get; set; }

        [StringLength(50, ErrorMessage = "Gönderi başlığı en fazla 50 karakter olabilir")]
        [Required(ErrorMessage = "Gönderi başlığını doldurunuz")]
        public string PostTitle { get; set; }

        [Required(ErrorMessage = "Gönderi içeriğinini doldurunuz")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Gönderi için resim seçiniz")]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Gönderinin kategorisini belirtiniz")]
        public int CategoryID { get; set; }
    }
}
