using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            //Bunu manager kısmında düzenle take metodu oluştur
            var datas = announcementManager.TGetList().Take(5).ToList();
            return View(datas);
        }
    }
}
