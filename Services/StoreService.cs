using StoreManagementBlazorApp.Entities;

namespace StoreManagementBlazorApp.Services
{
    public class StoreService
    {
        public List<Product> Products { get; private set; } = new()
        {
            new Product { Id = "1", Name = "Smartphone X", Category = "Electronics", Description = "High-end smartphone", Price = 15000000, Stock = 5, Image = "/images/phone.jpg" },
            new Product { Id = "2", Name = "Running Shoes", Category = "Fashion", Description = "Comfortable shoes", Price = 2000000, Stock = 20, Image = "/images/shoes.jpg" },
            new Product { Id = "3", Name = "Coffee Maker", Category = "Home", Description = "Brew perfect coffee", Price = 1500000, Stock = 8, Image = "/images/coffee.jpg" },
            new Product { Id = "4", Name = "Basketball", Category = "Sports", Description = "Official size", Price = 500000, Stock = 15, Image = "/images/basketball.jpg" },
            new Product { Id = "5", Name = "Novel Book", Category = "Books", Description = "Bestselling novel", Price = 120000, Stock = 0, Image = "/images/book.jpg" }
        };

        public User? CurrentUser { get; set; } = new User { Id = "u1", Name = "John Doe", Email = "john@example.com", Role = "customer" };

        public List<CartItem> Cart { get; private set; } = new();

        public void AddToCart(Product product, int quantity)
        {
            var item = Cart.FirstOrDefault(c => c.Product.Id == product.Id);
            if (item == null)
                Cart.Add(new CartItem { Product = product, Quantity = quantity });
            else
                item.Quantity += quantity;
        }

        public void UpdateCartQuantity(string productId, int quantity)
        {
            var item = Cart.FirstOrDefault(c => c.Product.Id == productId);
            if (item != null)
            {
                if (quantity <= 0) Cart.Remove(item);
                else item.Quantity = quantity;
            }
        }

        public void RemoveFromCart(string productId)
        {
            var item = Cart.FirstOrDefault(c => c.Product.Id == productId);
            if (item != null) Cart.Remove(item);
        }

        public decimal CartTotal => Cart.Sum(c => c.Product.Price * c.Quantity);

        public void ClearCart() => Cart.Clear();
    }
}
