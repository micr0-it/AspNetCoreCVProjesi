using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.ViewComponents.NavProfile
{
    public class NavProfileList : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavProfileList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        //Invoke Metodu Bu Şekilde Bir Hata Verecektir çünkü Task döndüremeyecektir
        //public async Task<IViewComponentResult> Invoke()
        //{
        //    var datas = await _userManager.FindByNameAsync(User.Identity.Name);
        //    return View();
        //}

        /// <InvokeAsync>
        /// task hatası almamamk için InvokeAsync olmalı
        /// </InvokeAsync>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Img = datas.ImgUrl;
            return View();
        }
    }
}
