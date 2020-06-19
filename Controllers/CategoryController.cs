using Microsoft.AspNetCore.Mvc;
using ArtFeverShop.Models;
using ArtFeverShop.Services;
using ArtFeverShop.Exceptions;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace ArtFeverShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;

        public CategoryController(ICategoryService categoryService, IItemService itemService)
        {
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        ItemsAndCategories itemsAndCategories = new ItemsAndCategories();

        public IActionResult Index()
        {
            itemsAndCategories.AllCategories = categoryService.ShowCategories();

            return View(itemsAndCategories);
        }

        public IActionResult AddCategory()
        {
            itemsAndCategories.AllCategories = categoryService.ShowCategories();

            return View(itemsAndCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                categoryService.CheckCategory(category);
            }
            catch (ErrorDataException)
            {
                itemsAndCategories.AllCategories = itemService.ShowCategories();
            
                return View(itemsAndCategories);
            }

            try
            {
                categoryService.AddCategory(category);
            }
            catch
            {
                itemsAndCategories.AllCategories = itemService.ShowCategories();
                ModelState.AddModelError("Category", "Тази категория вече съществува!");

                return View(itemsAndCategories);
            }

            return RedirectToAction("Index");
        }
        
    
        public IActionResult EditCategory()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var oldCategory = categoryService.FindCategory(id);
            if (oldCategory == null)
            {
                return RedirectToAction("Index");
            }

            itemsAndCategories.Category = oldCategory;
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }

        [HttpPost]
        public IActionResult EditCategory(ItemsAndCategories itemsAndCategories)
        {
            Category oldCategory = itemsAndCategories.Category;

            try
            {
                categoryService.CheckCategory(oldCategory);
                categoryService.EditCategory(itemsAndCategories.Category);
            }
            catch(ErrorDataException)
            {
                itemsAndCategories.Category = oldCategory;
                itemsAndCategories.AllCategories = itemService.ShowCategories();

                return View(itemsAndCategories);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            itemsAndCategories.Category = categoryService.FindCategory(id);
            itemsAndCategories.AllCategories = categoryService.ShowCategories();

            return View(itemsAndCategories);
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            categoryService.DeleteCategory(category.CategoryId);

            return RedirectToAction("Index", "Home");
        }
    }
}
