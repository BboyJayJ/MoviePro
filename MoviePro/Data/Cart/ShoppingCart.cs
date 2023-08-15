using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MoviePro.Migrations;
using MoviePro.Models;

namespace MoviePro.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set;}
        public List<ShoppingCartItem1> ShoppingCartItems1 { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = service.GetService<AppDbContext>();

            string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems1.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null) 
            {
                shoppingCartItem = new ShoppingCartItem1()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1,
                };
                _context.ShoppingCartItems1.Add(shoppingCartItem);
            }else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems1.FirstOrDefault(n => n.Movie.Id == movie.Id && ShoppingCartId== ShoppingCartId);

            if(shoppingCartItem!= null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }else
                {
                    _context.ShoppingCartItems1.Remove(shoppingCartItem);
                }
                _context.SaveChanges();
            }          
        }
        public List<ShoppingCartItem1> GetShoppingCartItems()
        {
            return ShoppingCartItems1 ?? (ShoppingCartItems1 =_context.ShoppingCartItems1.Where(n =>n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems1.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var item = await _context.ShoppingCartItems1.Where(n => n.ShoppingCartId== ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems1.RemoveRange(item);
            await _context.SaveChangesAsync();
        }
    }

    
}
