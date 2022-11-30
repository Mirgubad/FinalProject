using Core.Entities;
using Web.Areas.Admin.ViewModels.HomeMainSlider;

namespace Web.Services.Abstract
{
    public interface IHomeMainSliderService
    {
        Task<List<HomeMainSlider>> GetAllAsync();
    }
}
