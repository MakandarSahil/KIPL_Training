using KlingelnbergMachineManagement.Application.Services;
using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;
using KlingelnbergMachineManagement.Infrastructure.Repositories;
using KlingelnbergMachineManagement.Services;
using Microsoft.OpenApi.Models;
using KlingelnbergMachineManagement.Infrastructure.Options;
using KlingelnbergMachineManagement.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddSingleton<IDataParser, TextFileParser>();
builder.Services.AddSingleton<IDataParser, JsonFileParser>();

var dataFilePath = builder.Configuration.GetValue<string>("DataFilePath")
    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "matrix.txt");

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<IAssetRepository, MongoAssetRespository>();
builder.Services.AddScoped<IAssetWriteRepository, MongoAssetRespository>();

builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IMachineDataImportService, MachineDataImportService>();

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Klingelnberg API v1");
    c.RoutePrefix = "swagger";
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();

/* 
 FILE BASED MODE 

=> 
// Parsers
builder.Services.AddSingleton<IDataParser, TextFileParser>();
builder.Services.AddSingleton<IDataParser, JsonFileParser>();

var dataFilePath = builder.Configuration["DataFilePath"];

// File READ
builder.Services.AddScoped<IAssetReadRepository>(sp =>
{
    var parsers = sp.GetServices<IDataParser>();
    return new AssetRepository(parsers, dataFilePath);
});

// File WRITE
builder.Services.AddScoped<IAssetWriteRepository>(
    _ => new FileAssetWriteRepository(dataFilePath));

// Services
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IMachineDataImportService, MachineDataImportService>();
 
*/