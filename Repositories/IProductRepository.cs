using VisualStudio.Models;

namespace VisualStudio.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    Product Add(Product product);
    bool Update(Product product);
    bool Delete(Guid id);
}
