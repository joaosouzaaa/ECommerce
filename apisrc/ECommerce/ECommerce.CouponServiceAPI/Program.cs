using ECommerce.CouponServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.CouponServiceAPI.IoC;
using ECommerce.CouponServiceAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

AutoMapperConfigurations.Inicialize();
builder.Services.AddControllersConfiguration();
builder.Services.AddDIHandler(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
