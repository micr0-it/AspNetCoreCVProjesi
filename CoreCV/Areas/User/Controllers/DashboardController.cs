using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Welcome = datas.UserName + " " + datas.Surname;

            //İstatistikler için kısmen SOLID'ı eziyoruz
            Context c = new Context();
            ViewBag.datasComingMessage = c.WriterMessages.Where(x=>x.Receiver == datas.Email).Count();
            ViewBag.datasAnnouncement = c.Announcements.Count();
            ViewBag.datasAllUsers = c.Users.Count();
            ViewBag.datasSkills = c.Skills.Count();
            return View();
        }
    }
}
