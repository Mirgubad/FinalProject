using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsWithCategoryAsync()
        {
            var products = await _context.Products.Include(ct => ct.Category).ToListAsync();
           
            return products;
        }


        public async Task<List<Product>> FilterByCategoryId(int? categoryId)
        {
            return await _context.Products.Where(p => categoryId != null ? p.CategoryId == categoryId : true).ToListAsync();
        }


        public async Task<List<Product>> PaginateProductAsync(int page, int take)
        {
            var products = await _context.Products.Skip((page - 1) * take).Take(take).ToListAsync();
            return products;
        }

        public async Task<int> GetPageCountAsync(int take)
        {
            var pageCount = await _context.Products.CountAsync();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }

        public async Task<List<Product>> FilterByName(string? name)
        {
            return await _context.Products.Where(p => !string.IsNullOrEmpty(name) ? p.Title.Contains(name) : true).ToListAsync();
        }
    }

}
