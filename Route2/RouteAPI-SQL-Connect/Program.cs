using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RouteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RouteCloudDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
