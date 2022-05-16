using MassTransit;
using SharedLibrary;

RabbitMQSettings rMQSettings = new RabbitMQSettings();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + rMQSettings.userName + ":" + rMQSettings.password + "@" + rMQSettings.url);
    });
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
