using ArtFeverShop.Data;
using ArtFeverShop.Exceptions;
using ArtFeverShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace ArtFeverShop.Services
{
    public class CategoryService : ICategoryService
    {
        private ArtFeverShopContext db;

        public CategoryService(ArtFeverShopContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            FindCategory(category.CategoryName);
            db.Categories.Add(category);

            db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = FindCategory(id);
       
            if(db.Items.Any(item => item.CategoryName.Equals(category.CategoryName)))
               db.Items.RemoveRange(db.Items.Where(item => item.Category.CategoryName.Equals(category.CategoryName)));

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void EditCategory(Category newCategory)
        {
            var category = db.Categories.FirstOrDefault(item => item.CategoryId == newCategory.CategoryId);

            category.CategoryName = newCategory.CategoryName;
            category.Description = newCategory.Description;
            
            db.SaveChanges();
        }

        public void CheckCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.CategoryName) || string.IsNullOrEmpty(category.Description))
                throw new ErrorDataException();
        }

        public Category FindCategory(int id)
        {
            return db.Categories.FirstOrDefault(category => category.CategoryId == id);
        }

        public void FindCategory(string id)
        {
            if (db.Categories.FirstOrDefault(category => category.CategoryName == id) != null)
                throw new ErrorDataException();
        }

        public List<Category> ShowCategories()
        {
            return db.Categories.ToList();
        }
    }
}
