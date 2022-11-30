using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.OurVision;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OurVisionController : Controller
    {
        private readonly IOurVisionService _ourVisionService;

        public OurVisionController(IOurVisionService ourVisionService)
        {
            _ourVisionService = ourVisionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OurVisionCreateVM model)
        {
            var isSucceded = await _ourVisionService.CreateAsync(model);
            if (isSucceded) return RedirectToAction("index", "ourvision");
            return View(model);
        }
    }
}
