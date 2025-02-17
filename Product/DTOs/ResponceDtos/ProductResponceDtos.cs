using Product.DTOs.RequestDtos;

namespace Product.DTOs.ResponceDtos
{
    public class ProductResponceDtos : ProductRequestDtos
    {
        public Guid ProductId { get; set; }
    }
}
