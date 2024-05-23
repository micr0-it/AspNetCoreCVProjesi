using CoreProjeAPI.DAL.ApiContext;
using CoreProjeAPI.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using Context c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryListGetID(int id)
        {
            using Context c = new Context();
            var datas = c.Categories.Find(id);
            if (datas == null)
                return NotFound();
            else 
                return Ok(datas);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            using Context c = new Context();
            c.Add(category);
            c.SaveChanges();
            return Created("",category);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using Context c = new Context();
            var datas = c.Categories.Find(id);
            if (datas == null)
                return NotFound();
            else 
            { 
                c.Remove(datas); 
                c.SaveChanges(); 
                return NoContent(); 
            }               

        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using Context c = new Context();
            var datas = c.Find<Category>(category.CategoryID);
            if (datas == null)
                return NotFound();
            else 
            { 
                datas.Name = category.Name;
                c.Update(datas); 
                c.SaveChanges(); 
                return NoContent(); 
            }               

        }
    }
}
