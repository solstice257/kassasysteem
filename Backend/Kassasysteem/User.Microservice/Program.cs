using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using User.Microservice.Model;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Context;
using User.Microservice.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

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

app.MapGet("/user/get/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.GetUserById(id);
});

app.MapGet("/user/get/all", ([FromServices] IUserDAL db) =>
{
    return db.GetUsers();
});

app.MapPut("/user/update/{id}", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.UpdateUser(user);

});

app.MapPost("/user/add", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.AddUser(user);
});

app.MapDelete("/user/delete/{id}", ([FromServices] IUserDAL db, string id) =>
{
    db.DeleteUser(id);
});

app.Run();

public partial class Program { }