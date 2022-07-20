namespace ECommerce.PaymentServiceAPI.Ioc
{
    public static class OthersConfigurations
    {
        public static void AddOthersConfigurations(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", 
            builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed(origin => true)
                       //.AllowCredentials()
                       .AllowAnyOrigin();
                       //.WithOrigins("http://localhost:3000");
            }));
        }
    }
}
