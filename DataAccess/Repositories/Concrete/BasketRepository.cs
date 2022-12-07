using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketRepository(AppDbContext context,
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DecreaseCountAsync(int id)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var basket = await _context.Baskets
                .Include(bp => bp.BasketProducts)
                .FirstOrDefaultAsync(b => b.UserId == user.Id);

            if (basket != null)
            {
                foreach (var dbbasketProduct in basket.BasketProducts)
                {
                    if (dbbasketProduct.ProductId == id)
                    {
                        dbbasketProduct.Quantity--;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return true;
        }

        public async Task<Basket> GetBasketAsync(string userId)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserId == userId);
            return basket;
        }

        public async Task<Basket> GetBasketProducts()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return null;

            var basket = await _context.Baskets
                .Include(b => b.BasketProducts)
                .ThenInclude(bp => bp.Product)
                .FirstOrDefaultAsync(b => b.UserId == user.Id);

            return basket;
        }

        public async Task<bool> IncreaseCountAsync(int id)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;

            var basket = await _context.Baskets
                .Include(bp => bp.BasketProducts)
                .FirstOrDefaultAsync(b => b.UserId == user.Id);


            if (basket != null)
            {
                foreach (var dbbasketProduct in basket.BasketProducts)
                {
                    if (dbbasketProduct.ProductId == id)
                    {
                        dbbasketProduct.Quantity++;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null) return false;


            var basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.ProductId == id && bp.Basket.UserId == user.Id);
            if (basketProduct == null) return false;

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketProduct.ProductId);
            if (product == null) return false;

            _context.BasketProducts.Remove(basketProduct);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
