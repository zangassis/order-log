using Microsoft.AspNetCore.Mvc;
using OrderLog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LoggingService>();
builder.Services.AddScoped<NullLoggingService>();

var app = builder.Build();

app.MapPost("/", (
    [FromServices] LoggingService realService, 
    [FromServices] NullLoggingService nullService, 
    [FromBody] string? message) =>
{
    ILoggingService service = message is not null ? realService : nullService;

    service.Log(message);

    return Results.Ok();
});

app.Run();