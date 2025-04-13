using System.Globalization;
using backendModuleV.Core.Interfaces;

namespace backendModuleV.Infrastructure.Services.Import;

public class CsvPriceListParser : IPriceListParser
{
    private readonly string[] exts = new[] { ".csv", ".txt" };
    public bool CanParse(string filePath)
    {
        var e = Path.GetExtension(filePath).ToLowerInvariant();
        return exts.Contains(e);
    }
    public IEnumerable<(string Code, string Name, decimal? Price)> Parse(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(';');
            if (parts.Length < 3) continue;
            var code = parts[0].Trim();
            var name = parts[1].Trim();
            decimal? price = null;
            if (decimal.TryParse(parts[2], NumberStyles.Number, CultureInfo.InvariantCulture, out var p))
            {
                price = p;
            }
            yield return (code, name, price);
        }
    }
}