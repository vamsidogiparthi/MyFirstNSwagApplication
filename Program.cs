using MyFirstNSwagApplication;
using MyFirstNSwagApplication.TypeMappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions((options) =>
    {
        //registering custom json serializer for long type
        options.JsonSerializerOptions.Converters.Add(new LongJsonSerializer());
    })
    ;

builder.Services.AddEndpointsApiExplorer();
// An extension method to add the nSwag open api document generation service from NSwag
builder.Services.AddOpenApiDocument((document, serviceProvider) =>
{
    // Add a custom type mapper to the schema settings
    document.SchemaSettings.TypeMappers.Add(new LongTypeMapper()); 
});

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
