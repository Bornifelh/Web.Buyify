using Microsoft.AspNetCore.Mvc;

namespace Web.Buyify.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;

        public CartController()
        {
            _cart = new Cart();
        }

        public IActionResult Index()
        {
            return View(_cart.Items);
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

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            _cart.RemoveItem(productId);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCartItem(int productId, int quantity)
        {
            _cart.UpdateItemQuantity(productId, quantity);

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cart.Clear();

            return RedirectToAction("Index");
        }
    }

}
