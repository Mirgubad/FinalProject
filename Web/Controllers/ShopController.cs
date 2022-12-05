using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;

namespace Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _shopService.GetAllProductsWithCategoriesAsync();
            return View(model);
        }
    }
}
