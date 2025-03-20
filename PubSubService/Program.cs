using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubDemo.Consumer;

var builder = Host.CreateApplicationBuilder();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SellerServiceConsumer>();
    x.AddConsumer<InventoryServiceConsumer>();
    x.AddConsumer<DeliveryPartnerServiceConsumer>();
    x.AddConsumer<EmailServiceConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        // cfg.ReceiveEndpoint("another-create-order", ep =>
        // {
        //     ep.Consumer<SellerConsumer>();
        //     ep.Consumer<InventoryConsumer>();
        // });
        // cfg.ReceiveEndpoint("another-dispatch-order", ep =>
        // {
        //     ep.Consumer<DeliveryPartnerConsumer>();
        // });
        // cfg.ReceiveEndpoint("another-email", ep =>
        // {
        //     ep.Consumer<EmailConsumer>();
        // });
        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();
await app.StartAsync();

Console.ReadLine();

await app.StopAsync();