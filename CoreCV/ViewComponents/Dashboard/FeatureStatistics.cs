using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.SkillCount = context.Skills.Count();
            ViewBag.ReadedMssgCount = context.Messages.Where(p=>p.Status == false).Count();
            ViewBag.UnreadedMssgCount = context.Messages.Where(p=>p.Status == true).Count();
            ViewBag.ExperiencesCount = context.Experiences.Count();
            return View();
        }
    }
}
