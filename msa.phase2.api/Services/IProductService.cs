using Microsoft.AspNetCore.Mvc;
using msa.phase2.api.Models;
namespace msa.phase2.api.Services
{
    public interface IProductService
    {
        public  Task<IEnumerable<Product>> GetProducts();
        public  Task<Product> GetProduct(long id);
    }
}
