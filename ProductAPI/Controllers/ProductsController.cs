using Bootcamp_Domain.Interfaces;
using Bootcamp_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _productRepository.Update(id, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var newProduct = await _productRepository.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deleted = await _productRepository.DeleteById(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> ProductExists(Guid id)
        {
            var product = await _productRepository.GetById(id);
            return product != null;
        }
    }
}
