using Microsoft.AspNetCore.Mvc;
using Web.Buyify.Models;

namespace Web.Buyify.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly AppDbContext _dbContext;

        public CartController(AppDbContext dbContext)
        {
            _cart = new Cart();
            _dbContext = dbContext;
        }

        public IActionResult Details(int id)
        {
            var product = _dbContext.Articles.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View("Details", product);
        }

        public IActionResult AddToCart(int productId, string productName, decimal price, int quantity)
        {
            var item = new CartItem
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                Quantity = quantity
            };

            _cart.AddItem(item);

            return RedirectToAction("Panier");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            _cart.RemoveItem(productId);

            return RedirectToAction("Panier");
        }

        public IActionResult UpdateCartItem(int productId, int quantity)
        {
            _cart.UpdateItemQuantity(productId, quantity);

            return RedirectToAction("Panier");
        }

        public IActionResult ClearCart()
        {
            _cart.Clear();

            return RedirectToAction("Panier");
        }

        public IActionResult Panier()
        {
            return View(_cart.Items);
        }
    }
}
