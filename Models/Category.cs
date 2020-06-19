using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ArtFeverShop.Models
{
    public class Category 
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Моля, въведете име на категория")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Моля, въведете описание")]
        public string Description { get; set; }
    }
}
