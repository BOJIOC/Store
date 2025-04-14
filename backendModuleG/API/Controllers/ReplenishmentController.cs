using backendModuleG.Core.Interfaces;
using backendModuleG.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReplenishmentController : ControllerBase
{
    private readonly IReplenishmentService _service;

    public ReplenishmentController(IReplenishmentService service)
    {
        _service = service;
    }

    [HttpPost("propose")]
    public async Task<IActionResult> Propose([FromBody] ReplenishmentRequest request)
        => Ok(await _service.ProposeReplenishmentAsync(request));

    [HttpPost("execute")]
    public async Task<IActionResult> Execute([FromBody] List<ReplenishmentResult> results)
        => await _service.ExecuteReplenishmentAsync(results) ? Ok() : BadRequest("Ошибка подпитки");
}