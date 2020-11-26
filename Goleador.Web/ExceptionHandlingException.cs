using Goleador.Application.Shared.Exceptions;
using Goleador.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Goleador.Web
{
    public static class ExceptionHandlingExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exception = context.Features.Get<IExceptionHandlerFeature>().Error;
                    HttpStatusCode responseStatusCode;
                    if (exception != null)
                    {
                        if (exception is DomainException)
                        {
                            responseStatusCode = HttpStatusCode.BadRequest;
                        }
                        else if(exception is NotFoundException)
                        {
                            responseStatusCode = HttpStatusCode.NotFound;
                        }
                        else
                        {
                            responseStatusCode = HttpStatusCode.InternalServerError;
                        }

                        context.Response.StatusCode = (int)responseStatusCode;
                        await context.Response.WriteAsync(exception.Message);
                    }
                });
            });
        }
    }
}
