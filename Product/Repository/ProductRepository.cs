using Product.Database;
using Product.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using Product.IRepository;

namespace Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Entity.Product> AddProduct(Entity.Product product)
        {
            try
            {
                var addProduct = await _context.Products.AddAsync(product).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return product;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the product.", ex);
            }
        }

        public async Task<Entity.Product> GetProduct(Guid Id)
        {
            try
            {
                var getProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == Id).ConfigureAwait(false)
                    ?? throw new KeyNotFoundException("Product Not Found!");
                return getProduct;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the product.", ex);
            }
        }

        public async Task<List<Entity.Product>> GetallProducts()
        {
            try
            {
                var getProducts = await _context.Products.ToListAsync().ConfigureAwait(false);
                return getProducts;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the products.", ex);
            }
        }

        public async Task<Entity.Product> UpdateProduct(Entity.Product product)
        {
            try
            {
                var existingProduct = await GetProduct(product.ProductId).ConfigureAwait(false);
                if (existingProduct == null)
                {
                    throw new Exception("Product not found.");
                }
                
              _context.Entry(existingProduct).CurrentValues.SetValues(product);

                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return existingProduct;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the product.", ex);
            }
        }

        public async Task DeleteProduct(Guid Id)
        {
            var deleteProduct = await GetProduct(Id).ConfigureAwait(false)
                ?? throw new KeyNotFoundException("Product Not Found!");

            _context.Products.Remove(deleteProduct);
            await _context.SaveChangesAsync().ConfigureAwait(false);    

        }

    }

}
