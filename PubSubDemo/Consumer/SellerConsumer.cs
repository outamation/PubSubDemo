using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Consumer;

public class SellerConsumer : IConsumer<IOrder>
{
    public async Task Consume(ConsumeContext<IOrder> context)
    {
        Console.WriteLine($"[Seller]: Seller received order.");
    }
}