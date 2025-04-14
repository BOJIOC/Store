using backendModuleG.Core.Entities;
using backendModuleG.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PromotionsController : ControllerBase
{
    private readonly IPromotionService _service;

    public PromotionsController(IPromotionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var promo = await _service.GetByIdAsync(id);
        return promo == null ? NotFound() : Ok(promo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Promotion promo) => Ok(await _service.CreateAsync(promo));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Promotion promo)
    {
        if (id != promo.Id) return BadRequest();
        var updated = await _service.UpdateAsync(promo);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}