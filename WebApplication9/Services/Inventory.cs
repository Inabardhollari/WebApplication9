using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Services
{
    public class Inventory : IInventory
    {
        readonly AppDbContext db;
        public Inventory(AppDbContext _appDbContext)
        {
            db = _appDbContext;
        }
        public void addItems(InventoryModel inv)
        {
            db.Inventory.Add(inv);
            db.SaveChanges();
        }

        public bool deleteItems(int id)
        {
            if (db.Inventory.Any(x => x.Id == id))
            {
                db.Inventory.Remove(db.Inventory.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public InventoryModel getItemsById(int id)
        {
            return db.Inventory.Any(x => x.Id == id) ? db.Inventory.Include(item => item.Category).FirstOrDefault(item => item.Id == id) :null;
      
           // return db.Inventory.Any(x => x.Id == id) ? db.Inventory.FirstOrDefault(x => x.Id == id) : null;
        }
        public List<InventoryModel> getItems()
        {
            return db.Inventory.Any() ? db.Inventory.Include(item => item.Category).ToList() : null;
           // return db.Inventory.Any() ? db.Inventory.ToList() : null;
        }
        public bool updateItems(int id, InventoryModel model)
        {
            var objModel = db.Inventory.FirstOrDefault(x => x.Id == id);
            if (objModel!=null)
            {
                objModel.Name = model.Name;
                objModel.CategoryId = model.CategoryId;
                db.Inventory.Update(objModel);
                db.SaveChanges();
                return true; //update success
            }
            return false;
        }
    }
}
