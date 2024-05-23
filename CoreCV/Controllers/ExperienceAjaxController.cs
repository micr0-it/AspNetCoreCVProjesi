using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreCV.Controllers
{
    public class ExperienceAjaxController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
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

        public IActionResult ListExperience()
        {
            var datas = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(datas);
        }
        public IActionResult GetByID(int id)
        {
            var datasExperience = experienceManager.GetByID(id);
            var datas = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(datas);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var datas = JsonConvert.SerializeObject(experience);
            return Json(datas);
        }
        public IActionResult DeleteExperience(int id)
        {
            var datas = experienceManager.GetByID(id);
            experienceManager.TDelete(datas);
            return NoContent();
        }

        #endregion
    }
}
