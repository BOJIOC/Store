namespace backendModuleV.Core.Interfaces;

public interface IPriceListParser
{
    bool CanParse(string filePath);
    IEnumerable<(string Code, string Name, decimal? Price)> Parse(string filePath);
}