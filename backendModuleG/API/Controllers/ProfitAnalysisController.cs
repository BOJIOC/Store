using backendModuleG.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfitAnalysisController : ControllerBase
{
    private readonly IProfitAnalysisService _service;

    public ProfitAnalysisController(IProfitAnalysisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfits([FromQuery] DateTime from, [FromQuery] DateTime to)
        => Ok(await _service.GetProfitableProductsAsync(from, to));
}