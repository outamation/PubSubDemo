using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Consumer;

public class DeliveryPartnerServiceConsumer : IConsumer<IOrderDispatch>
{
    public async Task Consume(ConsumeContext<IOrderDispatch> context)
    {
        Console.WriteLine("[Delivery Partner Service]: Order dispatch request received.");
    }
}