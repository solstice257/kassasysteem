#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kassasysteem_backend.Models;

namespace Kassasysteem_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly KassasysteemContext _context;

        public ProductsController(KassasysteemContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            return await _context.Product
                .Select(x => productToDTO(x))
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(long id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return productToDTO(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, ProductDTO productDTO)
        {
            if (id != productDTO.productId)
            {
                return BadRequest();
            }

            var productvar = await _context.Product.FindAsync(id);
            if (productvar == null)
            {
                return NotFound();
            }

            productvar.productId = productDTO.productId;
            productvar.productName = productDTO.productName;
            productvar.productPrice = productDTO.productPrice;
            productvar.userPin = productDTO.userPin;
            productvar.taxAmount = productDTO.taxAmount;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProductExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDTO)
        {
            var product1 = new Product
            {
            productId = productDTO.productId,
            productName = productDTO.productName,
            productPrice = productDTO.productPrice,
            userPin = productDTO.userPin,
            taxAmount = productDTO.taxAmount,
        };

            _context.Product.Add(product1);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduct", new { id = Product.productId }, Product);
            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product1.productId },
                productToDTO(product1));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.productId == id);
        }

        private static ProductDTO productToDTO(Product productDTO) =>
            new ProductDTO
            {
                productId = productDTO.productId,
                productName = productDTO.productName,
                productPrice = productDTO.productPrice,
                userPin = productDTO.userPin,
                taxAmount = productDTO.taxAmount,
            };
    }
}
