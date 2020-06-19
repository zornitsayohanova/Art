using ArtFeverShop.Exceptions;
using ArtFeverShop.Models;
using ArtFeverShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtFeverShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        ItemsAndCategories itemsAndCategories = new ItemsAndCategories();

        public IActionResult Index(string id)
        {
            itemsAndCategories.AllItems = itemService.GetCategoryItems(id);
            itemsAndCategories.AllCategories = itemService.ShowCategories();
            itemsAndCategories.Category = itemService.FindCategory(id);

            return View(itemsAndCategories);
        }

        [HttpPost]
        public IActionResult Index()
        {
            itemsAndCategories.AllItems = itemService.ShowItems();
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }

        public IActionResult AddItem()
        {
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }

        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            try
            {
                itemService.CheckItem(item);
            }
            catch (ErrorDataException)
            {
                itemsAndCategories.AllCategories = itemService.ShowCategories();

                return View(itemsAndCategories);
            }
            try
            {
                itemService.AddItem(item);
            }
            catch (ErrorDataException)
            {
                itemsAndCategories.AllCategories = itemService.ShowCategories();
                ModelState.AddModelError("Item", "Този продукт вече съществува!");

                return View(itemsAndCategories);
            }

            itemsAndCategories.AllCategories = itemService.ShowCategories();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditItem()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var oldItem = itemService.FindItem(id);

            if (oldItem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            itemsAndCategories.Item = oldItem;
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }

        [HttpPost]
        public IActionResult EditItem(ItemsAndCategories itemsAndCategories)
        {
            Item oldItem = itemsAndCategories.Item;

            try
            {
                itemService.CheckItem(oldItem);
                itemService.EditItem(itemsAndCategories.Item);
            }
            catch (ErrorDataException)
            {
                itemsAndCategories.Item = oldItem;
                itemsAndCategories.AllCategories = itemService.ShowCategories();

                return View(itemsAndCategories);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteItem(int id)
        {
            itemsAndCategories.Item = itemService.FindItem(id);
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }

        [HttpPost]
        public IActionResult DeleteItem(Item item)
        {
            itemService.DeleteItem(item.ItemId);
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/Home/Details/{id}")]
        public IActionResult DetailsItem(int id)
        {
            var item = itemService.FindItem(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Home");
            }

            itemsAndCategories.Item = item;
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }
    }
}

