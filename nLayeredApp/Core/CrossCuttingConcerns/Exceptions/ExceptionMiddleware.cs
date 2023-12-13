using Core.CrossCuttingConcerns.Exceptions.Handlers;
//using Core.CrossCuttingConcerns.Logging;
//using Core.CrossCuttingConcerns.Serilog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    

    public ExceptionMiddleware(RequestDelegate next)
       
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
        
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            //await LogException(context, exception);
            await HandleExceptionAsync(context.Response, exception);
        }
    }


    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}