using Mapster;
using Product.DTOs.RequestDtos;
using Product.DTOs.ResponceDtos;

namespace Product.Mapper
{
    public class ProductMapper
    {
        public static void ProductMappings()
        {
            TypeAdapterConfig<Entity.Product, ProductResponceDtos>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Stock, src => src.Stock);

            TypeAdapterConfig<ProductRequestDtos, Entity.Product>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Stock, src => src.Stock);
        }
    }
}
