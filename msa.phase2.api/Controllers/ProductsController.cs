using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msa.phase2.api.Models;
using msa.phase2.api.Services;

namespace msa.phase2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            
            return Ok(products);
        }
       
        // GET: api/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return BadRequest();
            }

            return Ok(product);
        }
        /*
       // PUT: api/Products/5
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPut("{id}")]
       public async Task<IActionResult> PutProduct(long id, Product product)
       {
           if (id != product.Id)
           {
               return BadRequest();
           }

           _productService.Entry(product).State = EntityState.Modified;

           try
           {
               await _productService.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!ProductExists(id))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return NoContent();
       }

       // POST: api/Products
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPost]
       public async Task<ActionResult<Product>> PostProduct(Product product)
       {
         if (_context.Products == null)
         {
             return Problem("Entity set 'ProductContext.Products'  is null.");
         }
           _context.Products.Add(product);
           await _context.SaveChangesAsync();

          // return CreatedAtAction("GetProduct", new { id = product.Id }, product);
           return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
       }

       // DELETE: api/Products/5
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteProduct(long id)
       {
           if (_context.Products == null)
           {
               return NotFound();
           }
           var product = await _context.Products.FindAsync(id);
           if (product == null)
           {
               return NotFound();
           }

           _context.Products.Remove(product);
           await _context.SaveChangesAsync();

           return NoContent();
       }

       private bool ProductExists(long id)
       {
           return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
       }

       */
    }
}
