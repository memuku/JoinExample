using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Data.Model;

namespace JoinExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _employeeService.Add(employee);
            return Ok("345 added successfully.");
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            _employeeService.Update(employee);
            return Ok("Employee updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();

            _employeeService.Delete(employee);
            return Ok("213 deleted successfully.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }
        [HttpGet("EmployeeID")]
        public IActionResult GetEmployeeWithDepartmentName(int EmployeeID )
        {
            var employeesByDepartment = _employeeService.GetEmployeeWithDepartmentName(EmployeeID);
            return Ok(employeesByDepartment);
        }
    }
}

