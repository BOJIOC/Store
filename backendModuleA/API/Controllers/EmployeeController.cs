using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;
    public EmployeeController(IEmployeeService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) =>
        await _service.GetByIdAsync(id) is var emp && emp != null ? Ok(emp) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Employee employee) => Ok(await _service.CreateAsync(employee));
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Employee employee)
    {
        if (id != employee.Id) return BadRequest();
        var result = await _service.UpdateAsync(employee);
        return result == null ? NotFound() : Ok(result);
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}