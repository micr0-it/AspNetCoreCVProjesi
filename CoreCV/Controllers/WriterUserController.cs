using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreCV.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager writerUserManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {                      
            return View();
        }

        #region Ajax İle Dinamik Verileri Listeleme
        ///Neden AJAX
        ///Çünkü biz sayfada vitrin kısmında bir mesaj gönderme kısmı oluşturduk
        ///bunu da yaptıktan sonra otomatik bir sayfaya yönlendirmek istyior 
        ///bunu olmasını istemediğimizden ötürü ajax kullanacağız
        ///yan sayfa aslında her seferinde bir refresh olmayacak post olmayacak gibi düşün
        
        public IActionResult ListUser()
        {
            var datas = JsonConvert.SerializeObject(writerUserManager.TGetList());
            return Json(datas);
        }
        public IActionResult AddUser(WriterUser writerUser)
        {
            writerUserManager.TAdd(writerUser);
            var datas = JsonConvert.SerializeObject(writerUser);
            return Json(datas);
        }

        #endregion
    }
}
