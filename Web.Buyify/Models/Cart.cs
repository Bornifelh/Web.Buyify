using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Web.Buyify.Models
{
    public class Cart
    {
        private readonly List<CartItem> _items;
        private const string CartSessionKey = "Cart";

        public Cart()
        {
            _items = new List<CartItem>();
        }

        public IReadOnlyList<CartItem> Items => _items;

        public static Cart GetCart(HttpContext context)
        {
            var cartJson = context.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                var cart = new Cart();
                cartJson = JsonConvert.SerializeObject(cart);
                context.Session.SetString(CartSessionKey, cartJson);
                return cart;
            }
            return JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        public void AddItem(CartItem item)
        {
            var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _items.Add(item);
            }
        }

        public void RemoveItem(int productId)
        {
            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                _items.Remove(existingItem);
            }
        }

        public void UpdateItemQuantity(int productId, int quantity)
        {
            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity = quantity;
            }
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
