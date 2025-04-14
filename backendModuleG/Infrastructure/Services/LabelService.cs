using System.Net.Http.Json;
using backendModuleG.Core.DTO;
using backendModuleG.Core.Entities;
using backendModuleG.Core.Interfaces;
using backendModuleG.Core.Models;
using backendModuleG.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace backendModuleG.Infrastructure.Services;

public class LabelService : ILabelService
{
    private readonly HttpClient _http;
    private readonly ModuleGDbContext _db;

    public LabelService(HttpClient httpClient, ModuleGDbContext db)
    {
        _http = httpClient;
        _db = db;
    }

    public async Task<List<LabelDto>> GenerateLabelsAsync(List<int> productIds, bool includeMarketing)
    {
        // Теперь путь относительный
        var products = await _http.GetFromJsonAsync<List<ProductPriceDto>>("api/Product");

        var now = DateTime.Now;
        var promotions = includeMarketing
            ? await _db.Promotions.Where(p => now >= p.StartDate && now <= p.EndDate).ToListAsync()
            : new();

        var labels = new List<LabelDto>();

        foreach (var product in products!.Where(p => productIds.Contains(p.Id)))
        {
            var price = product.Price;
            var finalPrice = price;
            var hasDiscount = false;

            if (includeMarketing)
            {
                var productPromo = promotions.FirstOrDefault(p =>
                    p.Type == PromotionType.ProductDiscount && p.ProductIds!.Contains(product.Id));

                if (productPromo != null)
                {
                    finalPrice = price - price * (productPromo.DiscountPercent / 100);
                    hasDiscount = true;
                }
            }

            labels.Add(new LabelDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                OriginalPrice = price,
                FinalPrice = finalPrice,
                HasDiscount = hasDiscount,
                QrCodeImage = GenerateQr(product.Id.ToString())
            });
        }

        return labels;
    }

    private static byte[] GenerateQr(string text)
    {
        using var qr = new QRCodeGenerator();
        using var data = qr.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        using var code = new PngByteQRCode(data);
        return code.GetGraphic(20);
    }
}