using DataAccess.Repositories.Abstract;
using Web.Areas.Admin.Services.Abstract;
using Web.Services.Abstract;
using Web.ViewModels.Shop;

namespace Web.Services.Concrete
{
    public class ShopService : IShopService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ShopService(IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

       

        public async Task<ShopIndexVM> GetAllProductsWithCategoriesAsync()
        {
            var model = new ShopIndexVM
            {
                Products = await _productRepository.GetAllAsync(),
                Categories=await _productCategoryRepository.GetCategoryWithProduct()

            };
            return model;
        }
    }
}
