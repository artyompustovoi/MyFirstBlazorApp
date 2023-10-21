using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace BlazorApp.Models
{
    public class InMemoryCatalog : ICatalog
    {

        ConcurrentDictionary<Guid, Product> products_ = new ConcurrentDictionary<Guid, Product>();

        public InMemoryCatalog()
        {
            products_.TryAdd(Guid.NewGuid(), new("product1", 40m));
            products_.TryAdd(Guid.NewGuid(), new("product2", 50m));
            products_.TryAdd(Guid.NewGuid(), new("product3", 60m));
            products_.TryAdd(Guid.NewGuid(), new("product4", 70m));
            products_.TryAdd(Guid.NewGuid(), new("product5", 80m));
        }


        public ConcurrentDictionary<Guid, Product> GetProducts()
        {
            return products_;
        }
        public IActionResult CreateProduct(Product product)
        {
            IActionResult result;

            try
            {
                products_.TryAdd(Guid.NewGuid(), product);
                result = new CreatedResult(new Uri($"/add_prodoct/{product.Name}", UriKind.Relative), product);
            }
            catch (Exception exception)
            {
                result = new ObjectResult($"Error creating Product: {exception.Message}.");
            }

            return (result);
        }



        public Product GetProduct(Guid guid)
        {
            return products_[guid];
        }

        public void DeleteProduct(Guid guid)
        {
            products_.TryRemove(new KeyValuePair<Guid, Product>(guid, products_[guid]));
        }


        public void EditProduct(Guid guid, string newName, decimal newPrice)
        {
            products_[guid].Name = newName;
            products_[guid].Price = newPrice;

        }
    }
}
