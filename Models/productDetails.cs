namespace VisualStudio.Models;

public class ProductDetails
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Qta { get; set; }
}
