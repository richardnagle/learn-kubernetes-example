using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => $"[{DateTime.UtcNow:hh:MM:ss}] Server is running");

app.MapPost("/todo", async (ToDo toDo) =>
{
    return Results.Created( (Uri?)null, toDo);
});

app.Run();