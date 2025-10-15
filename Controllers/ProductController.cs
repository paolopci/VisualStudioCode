using Microsoft.AspNetCore.Mvc;
using VisualStudio.Models;
using VisualStudio.Repositories;

namespace VisualStudio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        var products = _repository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Product> GetById(Guid id)
    {
        var product = _repository.GetById(id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        var created = _repository.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, Product product)
    {
        if (id != product.Id && product.Id != Guid.Empty)
        {
            return BadRequest("The product ID in the body must match the URL.");
        }

        product.Id = id;
        var updated = _repository.Update(product);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var removed = _repository.Delete(id);
        if (!removed)
        {
            return NotFound();
        }

        return NoContent();
    }
}
