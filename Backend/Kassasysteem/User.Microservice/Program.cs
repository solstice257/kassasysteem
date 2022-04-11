using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using User.Microservice.Model;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Context;
using User.Microservice.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

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

app.MapGet("/user/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.GetUserById(id);
});

app.MapGet("/users", ([FromServices] IUserDAL db) =>
{
    return db.GetUsers();
});

app.MapPut("/user/{id}", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.UpdateUser(user);

});

app.MapPost("/user", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.AddUser(user);
});

app.Run();