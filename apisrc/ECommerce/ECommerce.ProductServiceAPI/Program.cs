using ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ProductServiceAPI.Ioc;
using ECommerce.ProductServiceAPI.IoC;
using ECommerce.ProductServiceAPI.Settings;

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
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
