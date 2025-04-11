using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovementController : ControllerBase
{
    private readonly IMovementService _service;
    public MovementController(IMovementService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) =>
        await _service.GetByIdAsync(id) is var m && m != null ? Ok(m) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Movement movement) => Ok(await _service.CreateAsync(movement));
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}