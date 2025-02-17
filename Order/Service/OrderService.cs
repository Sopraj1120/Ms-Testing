using Order.Dtos;
using Order.IRepository;
using Order.IService;

namespace Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ProductService _productService;

        public OrderService(IOrderRepository orderRepository, ProductService productService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
        }

        public async Task<OrderResponceDtos> CreateOrder(OrderRequestDtos orderRequest)
        {
            var products = await _productService.GetProducts();
            Console.WriteLine($"Retrieved {products.Count()} products from ProductService.");

            var product = products.FirstOrDefault(p => p.ProductId == orderRequest.ProductId);
            if (product == null)
            {
                Console.WriteLine($"Product with ID {orderRequest.ProductId} not found.");
            }
            else if (product.Stock < orderRequest.Quantity)
            {
                Console.WriteLine($"Product with ID {orderRequest.ProductId} has insufficient stock. Available: {product.Stock}, Requested: {orderRequest.Quantity}");
            }

            if (product == null || product.Stock < orderRequest.Quantity)
            {
                throw new Exception("Product not available or out of stock.");
            }

            var order = new Order.Entity.Order
            {
                Id = Guid.NewGuid(),
                ProductId = orderRequest.ProductId,
                Quantity = orderRequest.Quantity,
                TotalPrice = product.Price * orderRequest.Quantity
            };

            var createdOrder = await _orderRepository.AddOrder(order);


            return new OrderResponceDtos
            {
                Id = createdOrder.Id,
                ProductId = createdOrder.ProductId,
                Quantity = createdOrder.Quantity,
                TotalPrice = createdOrder.TotalPrice
            };
        }

        public async Task<IEnumerable<OrderResponceDtos>> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            return orders.Select(order => new OrderResponceDtos
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice
            });
        }

    }
}
