using System.Text.Json;
using Main.Server.Core.DTOs;
using Main.Server.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace generic_framework.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        UnauthorizedAccessException => 401,
                        ValidationException => 422,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var responseMessage = exceptionFeature.Error.Message;

                    // Serilog ile loglama
                    Log.Error(exceptionFeature.Error, "Unhandled exception occurred");

                    // Response DTO
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, responseMessage);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = false
                    }));
                });
            });
        }
    }
}
