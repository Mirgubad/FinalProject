using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Services.Abstract;
using Web.ViewModels.Basket;

namespace Web.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IBasketProductRepository _basketProductRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IBasketProductRepository basketProductRepository,
            IBasketRepository basketRepository,
            IProductRepository productRepository,
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _basketProductRepository = basketProductRepository;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<bool> Add(int modelId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var product = await _productRepository.GetAsync(modelId);
            if (product == null) return false;

            var basket = await _basketRepository.GetBasketAsync(user.Id);

            if (basket == null)
            {
                basket = new Basket
                {
                    UserId = user.Id
                };
                await _basketRepository.CreateAsync(basket);
            }

            var basketProduct = await _basketProductRepository.GetBasketProducts(modelId, basket.Id);
            if (basketProduct != null)
            {
                basketProduct.Quantity++;
                await _basketProductRepository.UpdateAsync(basketProduct);
            }
            else
            {
                basketProduct = new BasketProduct
                {
                    BasketId = basket.Id,
                    ProductId = product.Id,
                    Quantity = 1,
                    CreatedAt = DateTime.Now
                };
                await _basketProductRepository.CreateAsync(basketProduct);
            }

            return true;
        }

        public async Task<bool> DecreaseCountAsync(int id)
        {
            var isSucceded = await _basketRepository.DecreaseCountAsync(id);
            if (isSucceded) return true;
            return false;
        }

        public async Task<BasketIndexVM> GetBasketProducts()
        {
            var products = await _basketRepository.GetBasketProducts();

            var model = new BasketIndexVM();
            foreach (var product in products.BasketProducts)
            {
                var basketProducts = new BasketProductVM
                {
                    Id = product.ProductId,
                    Photoname = product.Product.Photoname,
                    Price = product.Product.Price,
                    Quantity = product.Quantity,
                    Title = product.Product.Title,

                };
                model.BasketProducts.Add(basketProducts);
            }

            return model;
        }

        public async Task<bool> IncreaseCountAsync(int id)
        {
            var isSucceded = await _basketRepository.IncreaseCountAsync(id);
            if (isSucceded) return true;
            return false;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var isSucceded = await _basketRepository.RemoveAsync(id);
            if (isSucceded) return true;
            return false;
        }
    }
}

