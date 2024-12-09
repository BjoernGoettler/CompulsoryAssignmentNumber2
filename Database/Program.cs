using Database;
using Database.DbContexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("develop");

builder.Services.AddDbContext<BookstoreContext>(
    options => options.UseMySql(connectionString:DatabaseConnectionFactory.GetMySqlConnectionString(),new MySqlServerVersion(new Version(8,0,0)))
);
var app = builder.Build();

app.MapOpenApi("/openapi/{documentName}/openapi.json");
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/develop/openapi.json", "Bookstore API v1"));


app.MapControllers();
app.Run();
