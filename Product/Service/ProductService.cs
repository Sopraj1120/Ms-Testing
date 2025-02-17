using Mapster;
using Product.DTOs.RequestDtos;
using Product.DTOs.ResponceDtos;
using Product.IRepository;
using Product.IService;

namespace Product.Service
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponceDtos> AddProduct(ProductRequestDtos productRequestDtos)
        {
            var product = productRequestDtos.Adapt<Entity.Product>();

            var addProduct = await _productRepository.AddProduct(product).ConfigureAwait(false);
            return addProduct.Adapt<ProductResponceDtos>();
        }

        public async Task<List<ProductResponceDtos>> GetAllProducts()
        {
            var getProducts = await _productRepository.GetallProducts().ConfigureAwait(false);
            return getProducts.Adapt<List<ProductResponceDtos>>();
        }

        public async Task<ProductResponceDtos> GetProduct(Guid Id)
        {
            var getProduct = await _productRepository.GetProduct(Id).ConfigureAwait(false);
            return getProduct.Adapt<ProductResponceDtos>();
        }

        public async Task<ProductResponceDtos> UpdateProducts(ProductRequestDtos productRequestDtos, Guid Id)
        {
            var product = await _productRepository.GetProduct(Id).ConfigureAwait(false);
            productRequestDtos.Adapt(product);
            var updateProduct = await _productRepository.UpdateProduct(product).ConfigureAwait(false);
            return updateProduct.Adapt<ProductResponceDtos>();
        }

        public async Task DeleteProduct(Guid Id)
        {
            await _productRepository.DeleteProduct(Id).ConfigureAwait(false);
        }
    }
}
