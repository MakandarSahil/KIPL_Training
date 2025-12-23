using KlingelnbergMachineManagement.Application.Services;
using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;
using KlingelnbergMachineManagement.Infrastructure.Repositories;
using KlingelnbergMachineManagement.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddSingleton<IDataParser, TextFileParser>(); 
builder.Services.AddSingleton<IDataParser, JsonFileParser>();

var dataFilePath = builder.Configuration.GetValue<string>("DataFilePath")
    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "matrix.txt");


builder.Services.AddSingleton<IAssetRepository>(sp =>
{ 
    var parsers = sp.GetServices<IDataParser>();
    return new AssetRepository(parsers, dataFilePath);
});

builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IMachineDataImportService>(sp =>
{
    var parsers = sp.GetServices<IDataParser>();
    var logger = sp.GetRequiredService<ILogger<MachineDataImportService>>();

    return new MachineDataImportService(parsers, dataFilePath);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Klingelnberg Machine Asset API",
        Version = "v1",
        Description = "API for managing machine-assets"
    });
});


builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Klingelnberg API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();