using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookstoreContext>(
    options => options.UseMySql(connectionString:DatabaseConnectionFactory.GetMySqlConnectionString(),new MySqlServerVersion(new Version(8,0,0)))
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();