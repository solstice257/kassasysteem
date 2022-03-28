using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Walking_Skeleton_LOUPE.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionstring));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwaggerUI();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using(var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(x => x.SerializeAsV2 = true);
app.MapGet("/user/{id}", ([FromServices] IDataRepository db, string id) =>
{
    return db.GetUserById(id);
});


app.MapGet("/users", ([FromServices] IDataRepository db) =>
   {
       return db.GetUsers();
   }
);

app.MapPut("/user/{id}", ([FromServices] IDataRepository db, User user) =>
{
    return db.UpdateUser(user);
});

app.MapPost("/user", ([FromServices] IDataRepository db, User user) =>
{
    return db.AddUser(user);
});
app.Run();
