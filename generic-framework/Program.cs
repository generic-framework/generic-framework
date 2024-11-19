using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Servislere Swagger'� ekliyoruz
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // Swagger i�in gerekli
builder.Services.AddSwaggerGen(options =>   // Swagger'� yap�land�r�yoruz
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "My API for demonstration",
    });
});

var app = builder.Build();

// Swagger'� yaln�zca geli�tirme ortam�nda aktif hale getiriyoruz.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger'� aktif hale getir
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = string.Empty; // Swagger UI'yi root (ana) dizine yerle�tirir
    });
}

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
