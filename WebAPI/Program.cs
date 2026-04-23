using Eventide.UserService.Application;
using Eventide.UserService.Infrastructure;
using Eventide.UserService.Application.EventHandlers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserRegisteredConsumer>();
    
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("eventide");
            h.Password("eventide_pass");
        });
        
        cfg.ReceiveEndpoint("user-registered-queue", e =>
        {
            e.ConfigureConsumer<UserRegisteredConsumer>(context);
        });
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();