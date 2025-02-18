namespace Order.IRepository
{
    public interface IOrderRepository
    {
        Task<Order.Entity.Order> AddOrder(Order.Entity.Order order);
        Task<IEnumerable<Order.Entity.Order>> GetOrders();
        Task<Order.Entity.Order> GetOrder(Guid Id);
        Task<Order.Entity.Order> UpdateOrder(Order.Entity.Order order);
        Task DeleteOrder(Guid Id);
    }
}
