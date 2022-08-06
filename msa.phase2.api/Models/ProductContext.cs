using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace msa.phase2.api.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
