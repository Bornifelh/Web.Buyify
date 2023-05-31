namespace Web.Buyify.Models
{
    public class Cart
    {
        private readonly List<CartItem> _items;

        public Cart()
        {
            _items = new List<CartItem>();
        }

        public IReadOnlyList<CartItem> Items => _items;

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
