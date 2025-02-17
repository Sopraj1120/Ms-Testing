

namespace Product.IService
{
    public interface IProductService
    {
        Task<ProductResponceDtos> AddProduct(ProductRequestDtos productRequestDtos);
        Task<List<ProductResponceDtos>> GetAllProducts();
        Task<ProductResponceDtos> GetProduct(Guid Id);
        Task<ProductResponceDtos> UpdateProducts(ProductRequestDtos productRequestDtos, Guid Id);
        Task DeleteProduct(Guid Id);
    }
}
