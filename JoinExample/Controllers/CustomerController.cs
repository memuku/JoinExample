using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Data.Model;

namespace JoinExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok("Customer added successfully.");
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok("Customer updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
                return NotFound();

            _customerService.Delete(customer);
            return Ok("Customer deleted successfully.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }
    }
}

