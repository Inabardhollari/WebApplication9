using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Services;

namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : Controller
    {
        private readonly IInventory inv;
        private readonly ICategory cat;
        public InventoryController(IInventory _inventory,ICategory _categoryRepository)
        {
            inv = _inventory;
            cat = _categoryRepository;
        }

        [HttpGet]
        public ActionResult<InventoryModel> GetAllItems()
        {
            return inv.getItems() != null ? Ok(inv.getItems()) : NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult<InventoryModel> GetItemsById(int id)
        {
            return inv.getItemsById(id) != null ? Ok(inv.getItemsById(id)) : NotFound();
        }

        [HttpPost]
        public ActionResult<InventoryModel> PostItem(InventoryModel model)
        {
            if (cat.getCategory(model.CategoryId) == null)
            {
                ModelState.AddModelError("CategoryId", "Invalid CategoryId.");
                return BadRequest(ModelState);
            }
            //ModelState Validation
            if (ModelState.IsValid)
            {
                inv.addItems(model);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public ActionResult<InventoryModel> updateItem(int id, InventoryModel model)
        {
            if (ModelState.IsValid)
            {
                return id != null ? (inv.updateItems(id, model) ? NoContent() : NotFound()) : BadRequest();
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("{id}")]
        public ActionResult<InventoryModel> deleteItem(int id)
        {
            return (id != null) ? (inv.deleteItems(id) ? NoContent() : NotFound()) : BadRequest();
        }
    }
}
