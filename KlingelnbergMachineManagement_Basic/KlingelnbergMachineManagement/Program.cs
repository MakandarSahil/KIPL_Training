// Program.cs
using KlingelnbergMachineManagement.Application.Services;
using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;
using KlingelnbergMachineManagement.Infrastructure.Repositories;
using KlingelnbergMachineManagement.Services;

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

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();