using ArtFeverShop.Models;
using System.Collections.Generic;

namespace ArtFeverShop.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void EditCategory(Category newCategory);
        void DeleteCategory(int id);
        void CheckCategory(Category category);
        Category FindCategory(int id);
        void FindCategory(string id);
        List<Category> ShowCategories();
    }
}
