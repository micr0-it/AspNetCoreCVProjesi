using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Message")]
    public class MessageController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var dataList = writerMessageManager.GetListReceiverMessage(p);
            return View(dataList);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var dataList = writerMessageManager.GetListSenderMessage(p);
            return View(dataList);
        }
        [HttpGet]
        [Route("SenderMessageDetails/{id}")]
        public IActionResult SenderMessageDetails(int id)
        {
            //Burada bir post işlemi olmayacak sadece görüntüleme yapacağımzıdan HttpGet actionresultumıza T türünde t parametremizi göndermeliyiz.
            WriterMessage writerMessage = writerMessageManager.GetByID(id);
            return View(writerMessage);
        }
        [HttpGet]
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            //Burada bir post işlemi olmayacak sadece görüntüleme yapacağımzıdan HttpGet actionresultumıza T türünde t parametremizi göndermeliyiz.
            WriterMessage writerMessage = writerMessageManager.GetByID(id);
            return View(writerMessage);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage) 
        {
            #region Session Bilgileri ile Mail Bilgileri Eşleştime
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.Sender = mail;
            writerMessage.SenderName = name;

            #region Receiver Name boş dönmemesi için
            Context c = new Context();
            var receiverNameSurname = c.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = receiverNameSurname;
            #endregion

            #endregion
            writerMessageManager.TAdd(writerMessage);
            
            //En üst düzeyde yazdığımız Route Attribut'e sayesinde artık buraya controller'ı eklememize gerek kalmadı
            return RedirectToAction("SenderMessage"); 
        }   
    }
}
