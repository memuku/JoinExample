using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Data.Model;

namespace YourProjectNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            _orderService.Add(order);
            return Ok("Order added successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            var existingOrder = _orderService.GetById(id);

            if (existingOrder == null)
            {
                return NotFound("Order not found.");
            }

            existingOrder.CustomerID = order.CustomerID;
            existingOrder.OrderDate = order.OrderDate;

            _orderService.Update(existingOrder);
            return Ok("Order updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetById(id);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            _orderService.Delete(order);
            return Ok("Order deleted successfully.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }
        [HttpGet("OrderID")]
        public IActionResult GetOrderWithCustomerName(int OrderID)
        {
            var ordersByCustomer = _orderService.GetOrderWithCustomerName(OrderID);
            return Ok(ordersByCustomer);
        }
    }
}
