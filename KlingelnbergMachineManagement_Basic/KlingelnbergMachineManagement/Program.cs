// Program.cs
using KlingelnbergMachineManagement.Application.Services;
using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;
using KlingelnbergMachineManagement.Infrastructure.Repositories;
using KlingelnbergMachineManagement.Services;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register data parsers (can add more parsers here)
builder.Services.AddSingleton<IDataParser, TextFileParser>();
//builder.Services.AddSingleton<IDataParser, JsonFileParser>();

// Register repository with data file path from configuration
var dataFilePath = builder.Configuration.GetValue<string>("DataFilePath")
    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "matrix.txt");

builder.Services.AddSingleton<IAssetRepository>(sp =>
{
    var parsers = sp.GetServices<IDataParser>();
    return new AssetRepository(parsers, dataFilePath);
});

// Register application service
builder.Services.AddScoped<IMachineService, MachineService>();

// Api endpoint support 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Klingelnberg Machine Asset API",
        Version = "v1",
        Description = "API for managing machine-asset relationships"
    });
});


builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Enable Swagger in development
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