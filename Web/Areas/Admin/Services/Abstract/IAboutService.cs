using Web.Areas.Admin.ViewModels.About;
using Web.Areas.Admin.ViewModels.AboutUs;
using Web.Areas.Admin.ViewModels.OurVision;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IAboutService
    {
        Task<AboutIndexVM> GetAsync();
        Task<bool> CreateAsync(AboutCreateVM model);
        Task<bool> IsExistAsync();
        Task<AboutUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(AboutUpdateVM model);
        Task DeleteAsync(int id);
    }
}
