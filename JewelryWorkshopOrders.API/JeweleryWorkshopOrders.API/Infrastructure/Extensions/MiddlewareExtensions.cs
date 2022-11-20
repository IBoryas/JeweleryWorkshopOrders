﻿using JewelryWorkshopOrders.API.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace JewelryWorkshopOrders.API.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
