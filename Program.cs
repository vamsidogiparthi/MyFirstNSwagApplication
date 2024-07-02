var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
// An extension method to add the nSwag open api document generation service from NSwag
builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // an web application middleware method to allow you
    // to use the nSwag open api generated swagger json document
    // default hosting local url: http://localhost:{portnumber}/swagger/v1/swagger.json
    app.UseOpenApi();
    // an web application middleware method to allow you to use the
    // nSwag prebuilt swagger ui to interact with your apis from the browser
    // default hosting local url: http://localhost:{portnumber}/swagger/index.html
    app.UseSwaggerUi(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
