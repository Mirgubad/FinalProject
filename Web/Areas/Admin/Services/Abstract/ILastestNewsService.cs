using Web.Areas.Admin.ViewModels.HomeMainSlider;
using Web.Areas.Admin.ViewModels.LastestNews;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface ILastestNewsService
    {
        Task<bool> CreateAsync(LastestNewsCreateVM model);
        Task<bool> UpdateAsync(LastestNewsUpdateVM model);
        Task<LastestNewsUpdateVM> GetUpdateModelAsync(int id);
        Task DeleteAsync(int id);
        Task<LastestNewsIndexVM> GetAllAsync();
        //Task<HomeMainSliderDetailsVM> GetDetailsAsync(int id);
    }
}
