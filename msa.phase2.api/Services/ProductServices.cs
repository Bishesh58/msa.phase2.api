using msa.phase2.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace msa.phase2.api.Services
{
    public class ProductServices: IProductService
    {
        private readonly ProductContext _context;
        public ProductServices(ProductContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task <Product> GetProduct(long id)
        {
           
            return await _context.Products.FindAsync(id);
        }


       

    }
}
