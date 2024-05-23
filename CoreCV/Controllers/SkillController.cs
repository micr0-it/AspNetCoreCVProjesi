using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Controllers
{
    [Authorize(Roles = "admin")]

    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var datas = skillManager.TGetList();
            return View(datas);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = skillManager.GetByID(id);
            skillManager.TDelete(skill);
            return RedirectToAction("Index"); //return View(); kod blogunu yazınca şimdi id'sini aldığımız entity silindiği için hata verecektir biz Index'e tekrardan dönmesini sağlayacağız
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = skillManager.GetByID(id);
            return View(skill);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }

    }
}
