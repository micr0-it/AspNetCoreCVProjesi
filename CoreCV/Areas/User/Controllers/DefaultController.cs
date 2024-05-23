using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DefaultController : Controller
    {       
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var datas = announcementManager.TGetList();
            return View(datas);
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            //Burada bir post işlemi olmayacak sadece görüntüleme yapacağımzıdan HttpGet actionresultumıza T türünde t parametremizi göndermeliyiz.
            var announcement = announcementManager.GetByID(id);
            return View(announcement);
        }
    }
}
