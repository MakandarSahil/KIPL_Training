// Program.cs
using KlingelnbergMachineManagement.Application.Services;
using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;
using KlingelnbergMachineManagement.Infrastructure.Repositories;
using KlingelnbergMachineManagement.Services;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register data parsers (can add more parsers here)
// we register / add interface , there implementations
// this will create instance which can be used thorugout the application


// AddSingleton - instance will be created when first time requested and then it will be used over the application whenever requested
// AddScooped - instance will be created within the scope 
/* for eg - in a single http request if we make another request then it will again create instance for it */
// AddTransient - new instance will be created for each request 

// this is shared among all (infra part) , its stateless 
builder.Services.AddSingleton<IDataParser, TextFileParser>(); 
//builder.Services.AddSingleton<IDataParser, JsonFileParser>();

// Register repository with data file path from configuration
var dataFilePath = builder.Configuration.GetValue<string>("DataFilePath")
    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "matrix.txt");


// singleton + factory 
// is a function that knows how to create an object instead of letting framework do it automatically
// here we need to pass IDataParser whihc DI can resolve but it can not resolve dataFilePath so we take help of factory
builder.Services.AddSingleton<IAssetRepository>(sp =>
{
    // sp gives access to the DI container
    var parsers = sp.GetServices<IDataParser>();
    return new AssetRepository(parsers, dataFilePath);
});

// Register application service
// one scope per user connection
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
        Description = "API for managing machine-assets"
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