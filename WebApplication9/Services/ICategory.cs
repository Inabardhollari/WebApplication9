using WebApplication9.Models;

namespace WebApplication9.Services
{
    public interface ICategory
    {
        void addC(CategoryModel model);
        CategoryModel getCategory(int id);
        List<CategoryModel> getCategories();
    }
}
