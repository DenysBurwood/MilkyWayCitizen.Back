using Microsoft.AspNetCore.Http;
using MilkyWayCitizen.Back.BLL.Exceptions;
using System.Collections.Generic;
using System.Text.Json;

namespace MilkyWayCitizen.Back.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate=requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch(Exception ex)
            {
                await HandleException(context,ex);
            }
        }

        public async Task HandleException(HttpContext context,Exception ex)
        {

            context.Response.ContentType="application/json";
            int statusCode = 400;
            switch(ex)
            {
                case RegisterFormException e:
                    await SendResponse(context, e);
                    break;
                case Exception:
                    context.Response.StatusCode=statusCode;
                    var response = new
                    {
                        message = ex.Message,
                    };
                    var jsonResponse = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(jsonResponse);
                    break;

                default:
                    throw new Exception("Impossibility");
            }
        }

        public async Task SendResponse(HttpContext context,MilkyWayException e)
        {
            context.Response.StatusCode=e.StatusCode;
            var response = new
            {
                message = e.Content,
            };
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }

    }
}
