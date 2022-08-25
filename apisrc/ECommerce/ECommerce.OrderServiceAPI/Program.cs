using ECommerce.OrderServiceAPI.IoC;
using ECommerce.OrderServiceAPI.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersConfiguration();
builder.Services.AddDIHandler(configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
