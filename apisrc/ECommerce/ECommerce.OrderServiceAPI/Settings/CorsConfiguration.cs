namespace ECommerce.OrderServiceAPI.Settings
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed(origin => true)
                       .AllowCredentials()
                       //.WithOrigins("Client side URI")
                       ;
            }));
        }
    }
}
