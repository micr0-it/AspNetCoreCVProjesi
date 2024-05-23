using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Controllers
{
    [Authorize(Roles = "admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.Title = "Deneyimler Sayfası";
            var datas = experienceManager.TGetList();
            return View(datas);
        }

        [HttpGet]
        public IActionResult AddExperience() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience) 
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = experienceManager.GetByID(id);
            experienceManager.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = experienceManager.GetByID(id);
            return View(experience);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
