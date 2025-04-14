using backendModuleG.Core.Interfaces;
using backendModuleG.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelController : ControllerBase
{
    private readonly ILabelService _service;

    public LabelController(ILabelService service)
    {
        _service = service;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Generate([FromBody] List<int> productIds, [FromQuery] bool includeMarketing = false)
        => Ok(await _service.GenerateLabelsAsync(productIds, includeMarketing));
}