using Web.Areas.Admin.ViewModels.HomeMainSlider;
using Web.Areas.Admin.ViewModels.OurVision;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IOurVisionService
    {
        Task<bool> CreateAsync(OurVisionCreateVM model);
        //Task<bool> UpdateAsync(HomeMainSliderUpdateVM model);
        //Task<HomeMainSliderUpdateVM> GetUpdateModelAsync(int id);
        //Task DeleteAsync(int id);
        //Task<HomeMainSliderIndexVM> GetAllAsync();
        //Task<HomeMainSliderDetailsVM> GetDetailsAsync(int id);
    }
}
