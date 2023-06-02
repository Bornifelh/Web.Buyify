using Microsoft.AspNetCore.Mvc;
using Web.Buyify.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Web.Buyify.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ISession _session;
        private const string CartSessionKey = "Cart";

        public CartController(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _session = httpContextAccessor.HttpContext.Session;
        }

        private Cart GetCart()
        {
            var cartJson = _session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                var cart = new Cart();
                cartJson = JsonConvert.SerializeObject(cart);
                _session.SetString(CartSessionKey, cartJson);
                return cart;
            }
            return JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        private void SaveCart(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _session.SetString(CartSessionKey, cartJson);
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

        public IActionResult AddToCart(int productId, string productName, string productDetails, string Img, decimal price, int quantity)
        {
            var item = new CartItem
            {
                ProductId = productId,
                ProductName = productName,
                ProductDetails = productDetails,
                Img = Img,
                Price = price,
                Quantity = quantity
            };

            var cart = GetCart();
            cart.AddItem(item);
            SaveCart(cart);

            return RedirectToAction("Panier");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            cart.RemoveItem(productId);
            SaveCart(cart);

            return RedirectToAction("Panier");
        }

        public IActionResult UpdateCartItem(int productId, int quantity)
        {
            var cart = GetCart();
            cart.UpdateItemQuantity(productId, quantity);
            SaveCart(cart);

            return RedirectToAction("Panier");
        }

        public IActionResult ClearCart()
        {
            var cart = new Cart();
            SaveCart(cart);

            return RedirectToAction("Panier");
        }

        public IActionResult Panier()
        {
            var cart = GetCart();
            return View("Panier", cart.Items);
        }
    }
}