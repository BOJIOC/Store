using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _service;
    public SupplierController(ISupplierService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) =>
        await _service.GetByIdAsync(id) is var supplier && supplier != null ? Ok(supplier) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Supplier supplier) => Ok(await _service.CreateAsync(supplier));
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Supplier supplier)
    {
        if (id != supplier.Id) return BadRequest();
        var result = await _service.UpdateAsync(supplier);
        return result == null ? NotFound() : Ok(result);
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}