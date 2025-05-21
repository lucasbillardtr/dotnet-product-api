using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductApi;
using ProductApi.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Add Sqlite database support
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers
builder.Services.AddControllers();


// Seed the database
builder.Services.AddScoped<IProductRepository, ProductRepository>();


// Application configuration
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    // Configure Swagger And Scalar
    app.UseSwagger(options => { options.RouteTemplate = "/openapi/{documentName}.json"; });
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Product API").WithTheme(ScalarTheme.Laserwave);
    });

    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    DatabaseSeeder.Seed(context);
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();