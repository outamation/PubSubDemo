using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Consumer;

public class DeliveryPartnerConsumer : IConsumer<IOrderDispatch>
{
    public async Task Consume(ConsumeContext<IOrderDispatch> context)
    {
        Console.WriteLine("[Delivery Partner]: Order dispatch request received.");
    }
}