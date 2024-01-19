using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions;

public static class ApplicationBuilderGlobalExceptionHandlingExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}
