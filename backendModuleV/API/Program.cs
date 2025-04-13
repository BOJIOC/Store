using backendModuleV.Core.Interfaces;
using backendModuleV.Infrastructure.Data;
using backendModuleV.Infrastructure.Services.Import;
using backendModuleV.Infrastructure.Services.InternetStore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IModuleAApiClient, ModuleAApiClient>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5027");
});
builder.Services.AddSingleton<IPriceListParser, CsvPriceListParser>();
builder.Services.AddScoped<IImportExportService, ImportExportService>();
builder.Services.AddScoped<IInternetStoreService, InternetStoreService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();