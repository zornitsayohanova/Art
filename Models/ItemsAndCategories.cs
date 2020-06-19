using System.Collections.Generic;

namespace ArtFeverShop.Models
{
    public class ItemsAndCategories
    {
        public Item Item { get; set; }
        public Category Category { get; set; }
        public List<Item> AllItems { get; set; }
        public List<Category> AllCategories { get; set; }
        public IEnumerable<Category> AllCategoriesNames { get; set; }
    }
}