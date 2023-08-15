using Business.Services;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace JoinExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            _departmentService.Add(department);
            return Ok("Good mami");
        }

        [HttpPut]
        public IActionResult Update(Department department)
        {
            _departmentService.Update(department);
            return Ok("Good mami güncelleeqweqwe");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Department department)
        {
            _departmentService.Delete(department);
            return Ok("Good mami sil");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var deparments = _departmentService.GetAll();
            return Ok(deparments);
        }
    }
}

