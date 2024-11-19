using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Servislere Swagger'ý ekliyoruz
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // Swagger için gerekli
builder.Services.AddSwaggerGen(options =>   // Swagger'ý yapýlandýrýyoruz
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "My API for demonstration",
    });
});

var app = builder.Build();

// Swagger'ý yalnýzca geliþtirme ortamýnda aktif hale getiriyoruz.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger'ý aktif hale getir
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = string.Empty; // Swagger UI'yi root (ana) dizine yerleþtirir
    });
}

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
