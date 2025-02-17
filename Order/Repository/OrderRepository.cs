

namespace Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }
        public async Task<Order.Entity.Order> AddOrder(Order.Entity.Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<IEnumerable<Order.Entity.Order>> GetOrders()
        {
            return await _context.orders.ToListAsync();
        }
    }
}
