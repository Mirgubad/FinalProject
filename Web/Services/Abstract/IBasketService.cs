﻿using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Basket;

namespace Web.Services.Abstract
{
    public interface IBasketService
    {
        Task<bool> Add(int productId);
        Task<BasketIndexVM> GetBasketProducts();
        Task<bool> RemoveAsync(int id);
        Task<bool> IncreaseCountAsync(int id);
        Task<bool> DecreaseCountAsync(int id);

    }
}
