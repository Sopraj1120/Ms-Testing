using Order.Dtos;

namespace Order.IService
{
    public interface IOrderService
    {

        Task<OrderResponceDtos> CreateOrder(OrderRequestDtos orderRequest);
        Task<IEnumerable<OrderResponceDtos>> GetOrders();
    }
}
