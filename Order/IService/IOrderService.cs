

namespace Order.IService
{
    public interface IOrderService
    {

        Task<dynamic> CreateOrder(OrderRequestDtos orderRequest);
        Task<IEnumerable<OrderResponceDtos>> GetOrders();
        Task<OrderResponceDtos> GetOrder(Guid Id);
        Task<OrderResponceDtos> UpdateOrder(OrderRequestDtos orderRequest, Guid Id);
        Task DeleteOrder(Guid Id);
    }
}
