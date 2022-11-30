using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Services.Abstract;
using Web.ViewModels.Home;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeMainSliderService _homeMainSliderService;

        public HomeController(IHomeMainSliderService homeMainSliderService)
        {
            _homeMainSliderService = homeMainSliderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexVM
            {
                HomeMainSlider =await _homeMainSliderService.GetAllAsync(),
            };
            return View(model);
        }


    }
}