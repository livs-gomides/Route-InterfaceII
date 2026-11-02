using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("RouteCloudDatabase");

builder.Services.AddDbContext<RouteDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error != null)
        {
            var error = exceptionHandlerPathFeature.Error;
            var message = error.InnerException?.Message ?? error.Message;
            await context.Response.WriteAsJsonAsync(new { detalheDoErro = message });
        }
    });
});

app.Run();