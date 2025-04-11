using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // Получение всех сотрудников
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);
        }

        // Получение сотрудника по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        // Добавление нового сотрудника
        [HttpPost]
        public async Task<ActionResult> Add(Employee employee)
        {
            await _service.AddAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // Обновление информации о сотруднике
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();
            await _service.UpdateAsync(employee);
            return NoContent();
        }

        // Удаление сотрудника
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
