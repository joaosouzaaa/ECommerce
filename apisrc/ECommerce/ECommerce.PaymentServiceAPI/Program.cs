using ECommerce.PaymentServiceAPI.IoC;
using Stripe;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDIHandler(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
