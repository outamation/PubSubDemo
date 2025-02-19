using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubDemo.Consumer;
using PubSubDemo.Producers;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddTransient<CreateOrderService>();
builder.Services.AddTransient<DispatchOrderService>();

builder.Services.AddMassTransit(x =>
{
    // x.AddConsumer<NotificationConsumer>();
    // x.AddConsumer<InventoryConsumer>();
    // x.AddConsumer<EmailOrderConfirmedConsumer>();

    x.UsingInMemory((context, cfg) =>
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

using (var scope = app.Services.CreateScope())
{
    
    while (true)
    {
        Console.WriteLine("Enter event to trigger:\nPress 1 to create order\nPress 2 to email\nPress 3 to exit.");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            var createOrderService = scope.ServiceProvider.GetRequiredService<CreateOrderService>();
            await createOrderService.CreateOrderAsync();
        }
        else if (choice == 2)
        {
            var dispatchOrderService = scope.ServiceProvider.GetRequiredService<DispatchOrderService>();
            await dispatchOrderService.DispatchOrderAsync();
        }
        else if (choice == 3)
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }
}

await app.StopAsync();