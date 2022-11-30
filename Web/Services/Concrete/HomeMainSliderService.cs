using Core.Entities;
using DataAccess.Repositories.Abstract;
using Web.Services.Abstract;

namespace Web.Services.Concrete
{
    public class HomeMainSliderService : IHomeMainSliderService
    {
        private readonly IHomeMainSliderRepository _homeMainSliderRepository;

        public HomeMainSliderService(IHomeMainSliderRepository homeMainSliderRepository)
        {
            _homeMainSliderRepository = homeMainSliderRepository;
        }
        public async Task<List<HomeMainSlider>> GetAllAsync()
        {
            var homeslider = await _homeMainSliderRepository.GetAllAsync();
            return homeslider;
        }
    }
}
