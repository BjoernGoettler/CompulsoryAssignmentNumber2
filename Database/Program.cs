using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
builder.Services.AddDbContext<BookstoreContext>(
    options => options.UseMySql(connectionString:DatabaseConnectionFactory.GetMySqlConnectionString(),new MySqlServerVersion(new Version(8,0,0)))
);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookstore API v1"));
}

app.Run();
