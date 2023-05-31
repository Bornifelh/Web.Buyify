using Microsoft.AspNetCore.Mvc;
using Web.Buyify.Models;

namespace Web.Buyify.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;

        public CartController()
        {
            _cart = new Cart();
        }

        public IActionResult Details()
        {
            return View("DetailsProduct", _cart.Items);
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
    }

}
