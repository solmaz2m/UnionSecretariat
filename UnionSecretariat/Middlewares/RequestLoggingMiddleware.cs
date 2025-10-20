
using System.Text;
using UnionSecretariat.Data;
using UnionSecretariat.Models;

namespace UnionSecretariat.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            var request = context.Request;
            var originalBodyStream = context.Response.Body;

            string requestBody = "";
            string responseBody = "";
            int statusCode = 200;
            string? errorMessage = null;

            try
            {
                // خواندن بدنه‌ی درخواست
                request.EnableBuffering();
                using (var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    requestBody = await reader.ReadToEndAsync();
                    request.Body.Position = 0;
                }

                // گرفتن پاسخ
                using var memStream = new MemoryStream();
                context.Response.Body = memStream;

                await _next(context);

                memStream.Seek(0, SeekOrigin.Begin);
                responseBody = await new StreamReader(memStream).ReadToEndAsync();
                memStream.Seek(0, SeekOrigin.Begin);
                await memStream.CopyToAsync(originalBodyStream);

                statusCode = context.Response.StatusCode;
            }
            catch (Exception ex)
            {
                statusCode = 500;
                errorMessage = ex.Message;
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
            finally
            {
                // ذخیره در دیتابیس
                try
                {
                    var log = new RequestLog
                    {
                        Method = request.Method,
                        Path = request.Path,
                        RequestBody = requestBody,
                        ResponseBody = responseBody,
                        StatusCode = statusCode,
                        ErrorMessage = errorMessage
                    };

                    db.RequestLogs.Add(log);
                    await db.SaveChangesAsync();
                }
                catch (Exception logEx)
                {
                    Console.WriteLine("خطا در ذخیره لاگ: " + logEx.Message);
                }

                context.Response.Body = originalBodyStream;
            }
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
