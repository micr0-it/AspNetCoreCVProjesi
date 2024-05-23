using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        readonly IConfiguration _configuration;

        public AdminNavbarMessageList(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var adminMail = _configuration["Admin:AdminMail"];
            //admin kısmındaki son üç mesaj kısmı gelecek
            var datas = writerMessageManager.GetListReceiverMessage(adminMail).OrderByDescending(p=>p.WriterMessageID).Take(3).ToList();
            return View();
        }
    }
}
