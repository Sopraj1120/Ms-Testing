using Order.Dtos;

namespace Order.IService
{
    public interface IOrderService
    {

        Task<dynamic> CreateOrder(OrderRequestDtos orderRequest);
        Task<IEnumerable<OrderResponceDtos>> GetOrders();
    }
}
