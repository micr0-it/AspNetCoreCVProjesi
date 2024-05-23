namespace CoreCV.Areas.User.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile Img { get; set; } ///for wwwroot staic files include

    }
}
