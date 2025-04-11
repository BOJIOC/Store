using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _service;

    public WarehouseController(IWarehouseService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) =>
        await _service.GetByIdAsync(id) is var warehouse && warehouse != null ? Ok(warehouse) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Warehouse warehouse) => Ok(await _service.CreateAsync(warehouse));
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Warehouse warehouse)
    {
        if (id != warehouse.Id) return BadRequest();
        var result = await _service.UpdateAsync(warehouse);
        return result == null ? NotFound() : Ok(result);
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}