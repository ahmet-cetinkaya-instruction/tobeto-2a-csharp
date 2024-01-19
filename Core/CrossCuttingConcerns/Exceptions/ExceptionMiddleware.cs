using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

// Middleware'ler arasında bir sonraki adıma geçişi sağlar.
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        // Delegate: Bir kod bütününü temsil eder.
        // RequestDelegate: Bir HTTP Request akışındaki bir sonraki adımı temsil eder.
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        // HttpContext: Bir HTTP Request akışını temsil eder.
        // Asynchronous Programing: Eş zamanlı programlama
        // async: Bir metodu eş zamanlı hale getirir. await kullanılacaksa eklenmesi gerekir.
        // Task: Bir asenkron işlemi temsil eder.

        try
        {
            //AddBrandResponse response = _brandService.Add(request);
            //return CreatedAtAction(nameof(GetList), response); // 201 Created

            // Örnek olarak add endpoint metodundaki kodların referansı _next'tedir.

            await _next(httpContext);
            // await: Bir sonraki adımın tamamlanmasını bekler.
        }
        catch (Exception exception)
        {
            await handleExceptionAsync(httpContext, exception);
        }
    }

    private Task handleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

        //if (exception.GetType() == typeof(BusinessException))
        //{
        //    BusinessException businessException = (BusinessException)exception; // casting
        //    return createBusinessProblemDetailsResponse(httpContext, businessException);
        //}
        if (exception is BusinessException businessException)
            return createBusinessProblemDetailsResponse(httpContext, businessException);

        return createInternalProblemDetailsResponse(httpContext, exception);
    }

    private Task createBusinessProblemDetailsResponse(
        HttpContext httpContext,
        BusinessException exception
    )
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        BusinessProblemDetails businessProblemDetails =
            new()
            {
                Title = "Business Exception",
                Type = "https://doc.rentacar.com/business",
                Status = StatusCodes.Status400BadRequest,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

        return httpContext.Response.WriteAsync(businessProblemDetails.ToString());
    }

    private Task createInternalProblemDetailsResponse(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        ProblemDetails problemDetails =
            new()
            {
                Title = "Internal Server Error",
                Type = "https://doc.rentacar.com/internal",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

        return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
    }
}
