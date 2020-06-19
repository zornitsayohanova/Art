using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtFeverShop.Models;
using ArtFeverShop.Services;

namespace ArtFeverShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService itemService;

        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            this.itemService = itemService;
        }

        ItemsAndCategories itemsAndCategories = new ItemsAndCategories();

        public IActionResult Index()
        {
            itemsAndCategories.AllItems = itemService.ShowItems();
            itemsAndCategories.AllCategories = itemService.ShowCategories();

            return View(itemsAndCategories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
