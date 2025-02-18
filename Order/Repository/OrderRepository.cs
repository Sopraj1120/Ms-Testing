

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

        public async Task<Order.Entity.Order> GetOrder(Guid Id)
        {
            return await _context.orders.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Order.Entity.Order> UpdateOrder(Order.Entity.Order order)
        {
            var existingOrder = await GetOrder(order.Id);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Order Not Found!");
            }
            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return order;
        }


        public async Task DeleteOrder(Guid Id)
        {
            var order = await GetOrder(Id);
            if (order == null)
            {
                throw new KeyNotFoundException("Order Not Found!");
            }
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
