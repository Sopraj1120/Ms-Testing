
namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add-order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDtos orderRequest)
        {
            var order = await _orderService.CreateOrder(orderRequest);
            return Ok(order);
        }

        [HttpGet("get-orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("get-order/{Id}")]
        public async Task<IActionResult> GetOrder(Guid Id)
        {
            var order = await _orderService.GetOrder(Id);
            return Ok(order);
        }

        [HttpPut("update-order/{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderRequestDtos orderRequest, Guid id)
        {
            var order = await _orderService.UpdateOrder(orderRequest, id);
            return Ok(order);
        }

        [HttpDelete("delete-order/{Id}")]
        public async Task<IActionResult> DeleteOrder(Guid Id)
        {
            await _orderService.DeleteOrder(Id);
            return Ok();
        }
    }
}
