using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubDemo.Consumer;

var builder = Host.CreateApplicationBuilder();

// builder.Services.AddTransient<CreateOrderService>();
// builder.Services.AddTransient<DispatchOrderService>();

builder.Services.AddMassTransit(x =>
{
    // x.AddConsumer<NotificationConsumer>();
    // x.AddConsumer<InventoryConsumer>();
    // x.AddConsumer<EmailOrderConfirmedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        // cfg.Host("localhost", "/", h =>
        // {
        //     h.Username("guest");
        //     h.Password("guest");
        // });
        cfg.ReceiveEndpoint("create-order", ep =>
        {
            ep.Consumer<SellerConsumer>();
            ep.Consumer<InventoryConsumer>();
        });
        cfg.ReceiveEndpoint("dispatch-order", ep =>
        {
            ep.Consumer<DeliveryPartnerConsumer>();
        });
        cfg.ReceiveEndpoint("email", ep =>
        {
            ep.Consumer<EmailConsumer>();
        });
        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();
await app.StartAsync();

Console.ReadLine();

await app.StopAsync();