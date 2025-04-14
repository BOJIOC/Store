using backendModuleV.Core.DTO.Import;
using backendModuleV.Core.DTO.Store;
using backendModuleV.Core.Interfaces;
namespace backendModuleV.Infrastructure.Services.Import;

public class ImportExportService : IImportExportService
{
    private readonly IEnumerable<IPriceListParser> _parsers;
    private readonly IModuleAApiClient _client;
    public ImportExportService(IEnumerable<IPriceListParser> parsers, IModuleAApiClient client)
    {
        _parsers = parsers; _client = client;
    }
    public async Task<ImportResult> CheckPriceListsAsync(string directoryPath, decimal? priceIncrease)
    {
        var r = new ImportResult();
        var files = Directory.GetFiles(directoryPath);
        foreach (var f in files)
        {
            var parser = _parsers.FirstOrDefault(x => x.CanParse(f));
            if (parser == null) continue;
            var rows = parser.Parse(f);
            foreach (var (Code, Name, Price) in rows)
            {
                if (Price == null)
                {
                    r.Errors.Add(new ImportError { FileName = Path.GetFileName(f), ProductCode = Code, Description = "Отсутствует цена" });
                    continue;
                }
                var fp = priceIncrease.HasValue ? Price.Value * (1 + priceIncrease.Value / 100m) : Price.Value;
                var exist = await _client.GetProductByCodeAsync(Code);
                if (exist == null)
                {
                    r.NewProducts.Add(new ImportedProductDto { Code = Code, Name = Name, Price = fp, PriceChanged = true });
                }
                else
                {
                    if (Math.Abs(exist.Price - fp) > 0.00001m)
                    {
                        r.UpdatedProducts.Add(new ImportedProductDto
                        {
                            Code = exist.Code,
                            Name = exist.Name,
                            Brand = exist.Brand,
                            Group = exist.Group,
                            Price = fp,
                            PriceChanged = true
                        });
                    }
                }
            }
        }
        return r;
    }
    public async Task<ImportResult> ImportPriceListsAsync(string directoryPath, decimal? priceIncrease)
    {
        var c = await CheckPriceListsAsync(directoryPath, priceIncrease);
        foreach (var np in c.NewProducts.Where(x => x.PriceChanged))
        {
            var dto = new ProductDto { Code = np.Code, Name = np.Name, Brand = np.Brand, Group = np.Group, Price = np.Price };
            await _client.CreateProductAsync(dto);
        }
        foreach (var up in c.UpdatedProducts.Where(x => x.PriceChanged))
        {
            var ex = await _client.GetProductByCodeAsync(up.Code);
            if (ex == null) continue;
            ex.Name = up.Name;
            ex.Brand = up.Brand;
            ex.Group = up.Group;
            ex.Price = up.Price;
            await _client.UpdateProductAsync(ex.Id, ex);
        }
        return c;
    }
    public async Task ExportProductsAsync(string targetDirectory)
    {
        var all = await _client.GetAllProductsAsync();
        foreach (var p in all)
        {
            var gf = Path.Combine(targetDirectory, Sanitize(p.Group));
            Directory.CreateDirectory(gf);
            var pf = Path.Combine(gf, Sanitize(p.Code));
            Directory.CreateDirectory(pf);
            var info = Path.Combine(pf, "info.txt");
            var text = $"Code: {p.Code}\r\nName: {p.Name}\r\nBrand: {p.Brand}\r\nPrice: {p.Price}";
            File.WriteAllText(info, text);
            if (!string.IsNullOrEmpty(p.ImageUrl) && File.Exists(p.ImageUrl))
            {
                var iname = Path.GetFileName(p.ImageUrl);
                var dst = Path.Combine(pf, iname);
                File.Copy(p.ImageUrl, dst, true);
            }
        }
    }
    private string Sanitize(string s)
    {
        foreach (var c in Path.GetInvalidFileNameChars()) s = s.Replace(c, '_');
        return s;
    }
}