using ImprovedApi.Api.Exceptions;
using ImprovedApi.Api.Responses;
using ImprovedApi.Infra.Loggers;
using ImprovedApi.Infra.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedApi.Api.Midlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, [FromServices] IImprovedUnitOfWork unitOfWork)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, unitOfWork);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IImprovedUnitOfWork unitOfWork)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var result = string.Empty;

            if (exception is EntityException)
            {
                code = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(new ResponseResult(null, (exception as EntityException).Notifications), new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (exception is UnauthorizedException)
            {
                code = HttpStatusCode.Unauthorized;
                result = JsonConvert.SerializeObject(new ResponseResult(null, (exception as UnauthorizedException).Notifications), new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message }, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

#if DEBUG
                ImprovedLogger.Write(exception);
#endif
            }

            unitOfWork.Rollback();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
