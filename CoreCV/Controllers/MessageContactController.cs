using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.Controllers
{
    [Authorize(Roles = "admin")]

    public class MessageContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var datas = messageManager.TGetList();
            return View(datas);
        }
        public IActionResult DeleteMessage(int id)
        {
            var datas = messageManager.GetByID(id);
            messageManager.TDelete(datas);
            return RedirectToAction("Index");
        }
        public IActionResult MessageDetails(int id)
        {
            var datas = messageManager.GetByID(id);
            return View(datas);
        }
    }
}
