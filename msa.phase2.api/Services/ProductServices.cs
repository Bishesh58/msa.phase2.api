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

        public async Task<Product> AddProduct(Product product)
        {
           await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<Product> DeleteProduct(long id)
        {
           var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<Product> UpdateProduct(long id, Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
               await _context.SaveChangesAsync();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return product;

        }
    }
}
