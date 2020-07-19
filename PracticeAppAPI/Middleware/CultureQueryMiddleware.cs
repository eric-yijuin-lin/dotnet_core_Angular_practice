using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomizedMiddleware
{
    public class CultureQueryMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureQueryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.Write("culture middlewawre in... ");
            var cultureQuery = context.Request.Query["culture"];

            if(!String.IsNullOrEmpty(cultureQuery))
            {
                var cultureInfo = new CultureInfo(cultureQuery);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;

                Console.WriteLine($"culture specified: {cultureQuery}");
            }
            else
                Console.WriteLine("culture is not specified, using: 'en' as default");

            await _next(context);
        }
    }
}