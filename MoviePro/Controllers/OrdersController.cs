using Microsoft.AspNetCore.Mvc;
using MoviePro.Data.Services;
using MoviePro.Models;
using System.Security.Claims;

namespace MoviePro.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IOrdersService _ordersService;
        public async Task <IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
    }
}
