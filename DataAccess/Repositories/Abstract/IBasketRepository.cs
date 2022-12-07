using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketAsync(string userId);
        Task<Basket> GetBasketProducts();
        Task<bool> RemoveAsync(int id);
        Task<bool> IncreaseCountAsync(int id);
        Task<bool> DecreaseCountAsync(int id);

    }
}
