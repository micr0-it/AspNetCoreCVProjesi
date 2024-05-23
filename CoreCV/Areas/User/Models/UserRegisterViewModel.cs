using System.ComponentModel.DataAnnotations;

namespace CoreCV.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz...")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz...")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz...")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrardan Giriniz...")]
        [Compare("Password", ErrorMessage = "Lütfen Şifrenizi Eşleşen Olacak Şekilde Giriniz...")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
    }
}
