using backendModuleV.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleV.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImportExportController : ControllerBase
{
    private readonly IImportExportService _service;
    public ImportExportController(IImportExportService service) => _service = service;

    [HttpGet("check")]
    public async Task<IActionResult> Check([FromQuery] string path, [FromQuery] decimal? priceIncrease)
    {
        var r = await _service.CheckPriceListsAsync(path, priceIncrease);
        return Ok(r);
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import([FromQuery] string path, [FromQuery] decimal? priceIncrease)
    {
        var r = await _service.ImportPriceListsAsync(path, priceIncrease);
        return Ok(r);
    }

    [HttpPost("export")]
    public async Task<IActionResult> Export([FromQuery] string targetPath)
    {
        await _service.ExportProductsAsync(targetPath);
        return Ok("Export done");
    }
}