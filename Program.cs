using InventoryGame;
using InventoryGame.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<ICharacterService, CharacterService>();

        builder.Services.AddOpenApi();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseExceptionHandler(new ExceptionHandlerOptions
        {
            StatusCodeSelector = ex => ex switch
            {
                CharacterNotFoundException => StatusCodes.Status404NotFound,
                ItemNotOwnedException => StatusCodes.Status400BadRequest,
                InventoryIsFullException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            },
            ExceptionHandler = async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                var statusCode = context.Response.StatusCode;

                var problem = new ProblemDetails
                {
                    Title = "An error occurred",
                    Detail = exception?.Message,
                    Status = statusCode,
                    Instance = context.Request.Path
                };

                switch (exception)
                {
                    case CharacterNotFoundException:
                        problem.Title = "Character not found";
                        break;
                    case ItemNotOwnedException:
                        problem.Title = "Item not owned";
                        break;
                    case InventoryIsFullException:
                        problem.Title = "Inventory is full";
                        break;
                }

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(problem);
            }
        });

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}
