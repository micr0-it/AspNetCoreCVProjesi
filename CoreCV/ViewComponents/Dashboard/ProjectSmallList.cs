using Microsoft.AspNetCore.Mvc;

namespace CoreCV.ViewComponents.Dashboard
{
    public class ProjectSmallList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
