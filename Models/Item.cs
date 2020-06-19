using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtFeverShop.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Моля, въведете име")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Моля, въведете кратко описание")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Моля, въведете дълго описание")]
        public string LongDescription { get; set; }
        [Required(ErrorMessage = "Моля, въведете цена")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Моля, въведете адрес на снимката")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Моля, въведете количество")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Моля, въведете име на категорията")]
        public string CategoryName { get; set; }
        public virtual Category Category { get; set; }
    }
}
