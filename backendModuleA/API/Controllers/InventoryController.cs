using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;
    public InventoryController(IInventoryService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) =>
        await _service.GetByIdAsync(id) is var inv && inv != null ? Ok(inv) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Inventory inv) => Ok(await _service.CreateAsync(inv));

    [HttpPost("finalize/{id}")]
    public async Task<IActionResult> Finalize(int id) =>
        await _service.FinalizeInventoryAsync(id) ? Ok() : NotFound();

    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}