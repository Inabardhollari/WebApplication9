using WebApplication9.Models;

namespace WebApplication9.Services
{
    public interface IInventory
    {
        void addItems(InventoryModel inv);
        bool updateItems(int id, InventoryModel model);
        bool deleteItems(int id);
        InventoryModel getItemsById(int id);
        List<InventoryModel> getItems();
    }
}
