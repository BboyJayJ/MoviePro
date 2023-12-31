﻿using MoviePro.Migrations;
using MoviePro.Models;

namespace MoviePro.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem1> items, string userId, string EmailAddress);

        Task <List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
