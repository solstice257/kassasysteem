using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using Order.Microservice.Model;
using Microsoft.EntityFrameworkCore;
using Order.Microservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Order.Microservice;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IOrderDAL, OrderDAL>();
builder.Services.AddDbContext<OrderDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8080")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                      });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.MapPost("/order/add", ([FromServices] IOrderDAL db, List<OrderModel> orders) =>
{
    return db.AddOrder(orders);
});

app.MapDelete("/order/delete", ([FromServices] IOrderDAL db, int id) =>
{
    return db.DeleteOrder(id);
});

app.MapGet("/order/get/all", ([FromServices] IOrderDAL db) =>
{
    return db.GetOrders();

});

app.Run();

public partial class Program { }