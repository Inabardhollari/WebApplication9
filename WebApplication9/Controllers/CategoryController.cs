using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Services;

namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory cat;
        private readonly IInventory inv;
        public CategoryController(ICategory _Cat, IInventory _inv)
        {
            cat = _Cat;
            inv = _inv;
        }

        [HttpPost("addCategory")]
        public ActionResult<CategoryModel> AddCategory([FromBody] CategoryModel model)
        {

            cat.addC(model);  
            return NoContent();

        }
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> getById(int id)
        {

            return cat.getCategory(id) != null ? Ok(cat.getCategory(id)) : null;
        }
        [HttpGet(Name = "getCategory")]
        public ActionResult<CategoryModel> GetAllCategory()
        {
            return cat.getCategories() != null ? Ok(cat.getCategories()) : NotFound();
        }

    }
}
