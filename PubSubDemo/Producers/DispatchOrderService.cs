using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Producers;

public class DispatchOrderService(IPublishEndpoint publishEndpoint)
{
    private readonly Order _order = new Order()
    {
        Id = 1,
        Email = "vivek.patel@outamation.com",
        Quantity = 4,
        ProductName = "Atomic Habits Book"
    };
    public async Task DispatchOrderAsync()
    {
        var orderDispatch = new OrderDispatch()
        {
            OrderId = _order.Id,
            DeliveryAddress = "8, Gokuldham society, Goregav East, Mumbai",
            PickupAddress = "Amazon warehouse, Pune",
            DeliveryPartnerId = 4
        };

        var email = new Email()
        {
            To = _order.Email,
            Cc = new List<string>(),
            Bcc = new List<string>(),
            Subject = $"Order: {_order.Id} dispatched.",
            Body =
                $"Order {_order.Id} has been dispatched successfully.\nSoon our delivery partner will deliver your order."
        };
        await PublishDispatchOrderAsync(orderDispatch, email);
    }

    private async Task PublishDispatchOrderAsync(IOrderDispatch orderDispatch, IEmail email)
    {
        await publishEndpoint.Publish(orderDispatch);
        await publishEndpoint.Publish(email);
    }
}