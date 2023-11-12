using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApplication9.Models;

namespace WebApplication9.Services
{
    public class Category : ICategory
    {
        private readonly AppDbContext db;
      
        public Category(AppDbContext _db)
        {
            db = _db;
        }

        public void addC(CategoryModel model)
        {
             db.category.Add(model);
             db.SaveChanges();
        }
        
        public List<CategoryModel> getCategories()
        {
            return db.category.Any() ? db.category.Include(x=>x.Items).ToList() : null; 
        }

        public CategoryModel getCategory(int id)
        {
            CategoryModel a = db.category.Any(x => x.Id == id) ? db.category
            .Include(category => category.Items)
            .FirstOrDefault(category => category.Id == id) : null;
            return a;
           // return db.category.Any(x => x.Id == id) ? db.category.FirstOrDefault(x => x.Id == id) : null;
        }
    }
}
