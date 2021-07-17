using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ApiServiceHub.Extensions
{
    public static class Extensions
    {
        public static void AddPermissaoUrls(this CorsPolicyBuilder builder, params string[] urls)
        {
            builder.WithOrigins(urls)
                   .AllowAnyHeader()
                   .WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS")
                   .AllowCredentials();
        }
    }
}
