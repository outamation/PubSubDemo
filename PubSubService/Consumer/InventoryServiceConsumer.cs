using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Consumer;

public class InventoryServiceConsumer : IConsumer<IOrder>
{
    public async Task Consume(ConsumeContext<IOrder> context)
    {
        Console.WriteLine($"[Inventory Service]: Order received successfully.");
    }
}