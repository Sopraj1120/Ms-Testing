namespace Order.IRepository
{
    public interface IOrderRepository
    {
        Task<Order.Entity.Order> AddOrder(Order.Entity.Order order);
        Task<IEnumerable<Order.Entity.Order>> GetOrders();
    }
}
