using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Controllers
{
    [Authorize(Roles = "admin")]

    public class MessageAdminController : Controller
    {
        readonly IConfiguration _configuration;

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public MessageAdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult ReceiverMessageList()
        {
            //appsettings'den mail getirildi
            var adminMail = _configuration["Admin:AdminMail"];
            var datas = writerMessageManager.GetListReceiverMessage(adminMail);
            return View();
        }
        public IActionResult SenderMessageList()
        {
            //appsettings'den mail getirildi
            var adminMail = _configuration["Admin:AdminMail"];
            var datas = writerMessageManager.GetListSenderMessage(adminMail);
            return View();
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var datas = writerMessageManager.GetByID(id);
            return View(datas);
        }
        public IActionResult DeleteAdminMessage(int id)
        {
            //todo Burayı eğer admin gönderense veya alıcıysa ona göre bir url döndürmesi yapılacak şekilde düzenle
            var datas = writerMessageManager.GetByID(id);
            writerMessageManager.TDelete(datas);
            return RedirectToAction("SenderMessageDetails");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage writerMessage)
        {
            writerMessage.Sender = _configuration["Admin:AdminMail"];
            writerMessage.SenderName = _configuration["Admin:AdminName"];
            writerMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            #region Receiver Name boş dönmemesi için
            Context c = new Context();
            var receiverNameSurname = c.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = receiverNameSurname;
            #endregion

            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessageDetails");
        }
    }
}
