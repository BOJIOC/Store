using backendModuleG.Core.Interfaces;
using backendModuleG.Infrastructure.Data;
using backendModuleG.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ModuleGDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient<IReplenishmentService, ReplenishmentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5027");
});
builder.Services.AddHttpClient<IReplenishmentService, ReplenishmentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5027");
});
builder.Services.AddHttpClient<IProfitAnalysisService, ProfitAnalysisService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5027"); // или порт модуля A
});
builder.Services.AddHttpClient<ILabelService, LabelService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5027"); // порт твоего модуля A
});
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddHttpClient<IReplenishmentService, ReplenishmentService>();
builder.Services.AddHttpClient<IProfitAnalysisService, ProfitAnalysisService>();
builder.Services.AddHttpClient<ILabelService, LabelService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();