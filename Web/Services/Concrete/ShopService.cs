using Core.Entities;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.Product;
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

        public async Task<List<Product>> FilterByCategoryId(int id)
        {
            var products = await _productRepository.FilterByCategoryId(id);
            return products;
        }

        public async Task<List<Product>> FilterByName(string name)
        {
            var products = await _productRepository.FilterByName(name);
            return products;
        }

        public async Task<ShopIndexVM> GetAllProductsWithCategoriesAsync(ShopIndexVM model)
        {
            var products = await _productRepository.PaginateProductAsync(model.Page, model.Take);
            var pageCount = await _productRepository.GetPageCountAsync(model.Take);
          
            model = new ShopIndexVM
            {
                Products = products,
                Categories = await _productCategoryRepository.GetCategoryWithProduct(),
                PageCount = pageCount,
                Page = model.Page,
                Take = model.Take
            };
            return model;
        }
    }
}
