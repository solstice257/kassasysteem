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

app.MapGet("/user/{id}", ([FromServices] UserDbContext db, string id) =>
{
    return db.User.Where(x => x.userPin == id).FirstOrDefault();
});

app.MapGet("/users", ([FromServices] UserDbContext db) =>
{
    return db.User.ToList();
});

app.MapPut("/user/{id}", ([FromServices] UserDbContext db, UserModel user) =>
{
    db.User.Update(user);
    db.SaveChanges();
    return db.User.Where(x => x.userPin == user.userPin).FirstOrDefault();

});

app.MapPost("/user", ([FromServices] UserDbContext db, UserModel user) =>
{
    db.User.Add(user);
    db.SaveChanges();
    return db.User.ToList();
});

app.Run();