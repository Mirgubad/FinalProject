using Core.Entities;
using Web.ViewModels.Shop;

namespace Web.Services.Abstract
{
    public interface IShopService
    {
        Task<ShopIndexVM> GetAllProductsWithCategoriesAsync(ShopIndexVM model);
        Task<List<Product>> FilterByCategoryId(int id);
        Task<List<Product>> FilterByName(string name);

    }
}
