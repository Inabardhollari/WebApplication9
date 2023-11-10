namespace WebApplication9.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<InventoryModel>? Items { get; set; } 
    }
}
