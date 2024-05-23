using BusinessLayer.Concrete;
using CoreCV.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]

    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Surname = datas.Surname;
            userEditViewModel.Name = datas.Name;
            userEditViewModel.ImgUrl = datas.ImgUrl;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            #region User Img Güncelleme
            if (userEditViewModel.Img != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViewModel.Img.FileName);
                var imgName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimg/" + imgName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEditViewModel.Img.CopyToAsync(stream);
                user.ImgUrl = imgName;
            }
            #endregion
            
            user.Surname = userEditViewModel.Surname;
            user.Name = userEditViewModel.Name;
            
            #region User Pwd Güncelleme
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
            #endregion
           
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) 
                return RedirectToAction("Index","Default"); 
            return View();
        }
    }
}
