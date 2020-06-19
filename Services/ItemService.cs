using ArtFeverShop.Data;
using ArtFeverShop.Exceptions;
using ArtFeverShop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ArtFeverShop.Services
{
    public class ItemService : IItemService
    {
        private ArtFeverShopContext db;

        public ItemService(ArtFeverShopContext db)
        {
            this.db = db;
        }

        public void CheckItem(Item item)
        {
            if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.ShortDescription) || 
                string.IsNullOrEmpty(item.LongDescription) || item.Price <= 0 ||
                string.IsNullOrEmpty(item.ImageUrl) || item.Quantity <= 0)

                throw new ErrorDataException();
        }

        public void AddItem(Item item)
        {
            FindItem(item.Name);
            db.Items.Add(item);

            db.SaveChanges();
        }

        public void EditItem(Item newItem)
        {
            CheckItem(newItem);

            var item = db.Items.FirstOrDefault(item => item.ItemId.Equals(newItem.ItemId));

            item.Name = newItem.Name;
            item.ShortDescription = newItem.ShortDescription;
            item.ShortDescription = newItem.ShortDescription;
            item.LongDescription = newItem.LongDescription;
            item.Price = newItem.Price;
            item.ImageUrl = newItem.ImageUrl;
            item.Quantity = newItem.Quantity;
            item.CategoryName = newItem.CategoryName;
            item.Category = newItem.Category;

            db.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = FindItem(id);
            db.Items.Remove(item);

            db.SaveChanges();
        }

        public Item FindItem(int id)
        {
            return db.Items.FirstOrDefault(item => item.ItemId == id);
        }

        public void FindItem(string id)
        {
            if (db.Items.FirstOrDefault(item => item.Name == id) != null)
                throw new ErrorDataException();
        }

        public Category FindCategory(string id)
        {
            return db.Categories.FirstOrDefault(category => category.CategoryName == id);
        }

        public List<Item> ShowItems()
        {
            return db.Items.ToList();
        }

        public List<Category> ShowCategories()
        {
            return db.Categories.Distinct().ToList();
        }

        public List<Item> GetCategoryItems(string id)
        {
            return db.Items.Where(item => item.CategoryName == id).ToList();
        }
    }
}
