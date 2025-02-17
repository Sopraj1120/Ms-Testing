using Product.DTOs.ResponceDtos;

namespace Product.IRepository
{
    public interface IProductRepository
    {
        Task<Entity.Product> AddProduct(Entity.Product product);
        Task<List<Entity.Product>> GetallProducts();
        Task<Entity.Product> GetProduct(Guid Id);
        Task<Entity.Product> UpdateProduct(Entity.Product product);
        Task DeleteProduct(Guid Id);
        
    }
}
