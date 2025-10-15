using System.Collections.Concurrent;
using VisualStudio.Models;

namespace VisualStudio.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<Guid, Product> _products = new();

    public InMemoryProductRepository()
    {
        var sampleProducts = new[]
        {
            new Product { Name = "Laptop", Description = "Ultrabook 13\" touchscreen", Price = 1499.99m },
            new Product { Name = "Monitor", Description = "27\" 4K IPS display", Price = 399.50m },
            new Product { Name = "Mouse", Description = "Wireless ergonomic mouse", Price = 59.90m }
        };

        foreach (var product in sampleProducts)
        {
            _products[product.Id] = product;
        }
    }

    public IEnumerable<Product> GetAll() => _products.Values;

    public Product? GetById(Guid id) => _products.TryGetValue(id, out var product) ? product : null;

    public Product Add(Product product)
    {
        if (product.Id == Guid.Empty)
        {
            product.Id = Guid.NewGuid();
        }

        _products[product.Id] = product;
        return product;
    }

    public bool Update(Product product)
    {
        if (product.Id == Guid.Empty)
        {
            return false;
        }

        if (!_products.ContainsKey(product.Id))
        {
            return false;
        }

        _products[product.Id] = product;
        return true;
    }

    public bool Delete(Guid id) => _products.TryRemove(id, out _);
}
