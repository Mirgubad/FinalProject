using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Web.Services.Abstract;
using Web.ViewModels.Basket;

namespace Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _basketService.GetBasketProducts();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(BasketAddVM model)
        {
            var isSucceded = await _basketService.Add(model.Id);
            if (!isSucceded) return NotFound();
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _basketService.RemoveAsync(id);
            if (isDeleted) return RedirectToAction("Index", "basket");
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> IncreaseCount(int id)
        {
            if (!await _basketService.IncreaseCountAsync(id)) return NotFound();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DecreaseCount(int id)
        {
            if (!await _basketService.DecreaseCountAsync(id)) return NotFound();
            return Ok();
        }

    }
}
