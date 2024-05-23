using CoreCV.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    [Route("User/[controller]/[action]")]

    public class RegisterController : Controller
    {
        #region Identity Mimarisi İle Yapılan Register İşlemi - (N Tier Arch Mimarisinden Farklı Bir Mimari Görüyoruz)

        #region DependencyInjection CRUD
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegister)
        {
            if (ModelState.IsValid)
            {
                WriterUser writerUser = new WriterUser()
                {
                    Name = userRegister.Name,
                    Surname = userRegister.Surname,
                    UserName = userRegister.UserName,
                    Email = userRegister.Email,
                    ImgUrl = userRegister.ImgUrl
                };
               if(userRegister.Password == userRegister.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(writerUser, userRegister.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return View(userRegister);
        }
        #endregion
    }
}
