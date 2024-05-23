using Microsoft.AspNetCore.Mvc;

namespace CoreCV.ViewComponents.Dashboard
{
    public class GuestMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
