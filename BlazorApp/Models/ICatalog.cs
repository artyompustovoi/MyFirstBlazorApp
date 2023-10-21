using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace BlazorApp.Models
{
    public interface ICatalog
    {
        public ConcurrentDictionary<Guid, Product> GetProducts();
        public IActionResult CreateProduct(Product product);
        public Product GetProduct(Guid guid);
        public void DeleteProduct(Guid guid);
        public void EditProduct(Guid guid, string newName, decimal newPrice);
    }
}