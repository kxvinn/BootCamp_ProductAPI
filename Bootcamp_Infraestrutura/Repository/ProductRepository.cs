using Bootcamp_Domain.Interfaces;
using Bootcamp_Domain.Models;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bootcamp_Infraestrutura.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDataContext _productRepository;

        public ProductRepository(ApplicationDataContext context)
        {
            _productRepository = context;
        }

        public async Task<Product> Add(Product product)
        {
            _productRepository.Products.Add(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var product = await _productRepository.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _productRepository.Products.Remove(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.Products.FindAsync(id);
        }

        public async Task<Product> Update(Guid id, Product product)
        {
            var existingProduct = await _productRepository.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            _productRepository.Products.Update(existingProduct);
            await _productRepository.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product> SaveChanges()
        {
            await _productRepository.SaveChangesAsync();
            return null;
        }
    }
}
