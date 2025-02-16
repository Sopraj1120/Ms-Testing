using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.DTOs.RequestDtos;
using Product.IService;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(ProductRequestDtos productRequestDtos)
        {
            var addProduct = await _productService.AddProduct(productRequestDtos).ConfigureAwait(false);
            return Ok(addProduct);
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var getProducts = await _productService.GetAllProducts().ConfigureAwait(false);
            return Ok(getProducts);
        }

        [HttpGet("get-product/{Id}")]
        public async Task<IActionResult> GetProduct(Guid Id)
        {
            var getProduct = await _productService.GetProduct(Id).ConfigureAwait(false);
            return Ok(getProduct);
        }

        [HttpPut("update-product/{Id}")]
        public async Task<IActionResult> UpdateProduct(ProductRequestDtos productRequestDtos, Guid Id)
        {
            var updateProduct = await _productService.UpdateProducts(productRequestDtos, Id).ConfigureAwait(false);
            return Ok(updateProduct);
        }

        [HttpDelete("delete-product/{Id}")]
        public async Task<IActionResult> DeleteProduct(Guid Id)
        {
            await _productService.DeleteProduct(Id).ConfigureAwait(false);
            return Ok();
        }
    }
}
