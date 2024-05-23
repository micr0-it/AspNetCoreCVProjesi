using CoreCV.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.Controllers
{
    [AllowAnonymous] //Yetkisiz bir giriş olduğunda buraya yönlendirebilmek adına ayarları kullanma gibisinden
    [Area("User")]
    [Route("User/[controller]/[action]")]

    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;

        public LoginController(SignInManager<WriterUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.Username, userLoginViewModel.Password,true,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("","Hatalı Kullanıcı Adı veya Şifre");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            //Session bilgilerini silme
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
