using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
// An extension method to add the nSwag open api document generation service from NSwag
builder.Services.AddOpenApiDocument((document, serviceProvider) => 
{
    document.DocumentName = "development_v1";
    document.PostProcess = d => d.Info.Title = "Arcade APIs - Development";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // an web application middleware method to allow you
    // to use the nSwag open api generated swagger json document
    // default hosting local url: http://localhost:{portnumber}/swagger/v1/swagger.json
    app.UseOpenApi((settings) =>
    {
        settings.Path = $"/arcadeservice/swagger/swagger.json";
        // if you have added a custom name above. You provide it here as well. Otherwise it will fail
        settings.DocumentName = "development_v1";
    });
    // an web application middleware method to allow you to use the
    // nSwag prebuilt swagger ui to interact with your apis from the browser
    // default hosting local url: http://localhost:{portnumber}/swagger/index.html
    app.UseSwaggerUi((settings) =>
    {
        settings.Path = "/arcadeservice/swagger";
        settings.DocumentPath = "/arcadeservice/swagger/swagger.json";        
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
