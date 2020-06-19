using ArtFeverShop.Models;
using System.Collections.Generic;

namespace ArtFeverShop.Services
{
    public interface IItemService
    {
        void AddItem(Item item);
        void EditItem(Item newItem);
        void DeleteItem(int id);
        Item FindItem(int id);
        void FindItem(string id);
        void CheckItem(Item item);
        Category FindCategory(string id);
        List<Item> ShowItems();
        List<Category> ShowCategories();
        List<Item> GetCategoryItems(string categoryName);
    }
}
