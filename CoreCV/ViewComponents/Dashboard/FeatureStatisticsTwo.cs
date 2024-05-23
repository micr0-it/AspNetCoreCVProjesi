using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.ViewComponents.Dashboard
{
    public class FeatureStatisticsTwo : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Portfolios = c.Portfolios.Count();
            ViewBag.Messages = c.Messages.Count();
            ViewBag.Services = c.Services.Count();
            return View();
        }
    }
}
