using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Producers;

public class CreateOrderService(IPublishEndpoint publishEndpoint)
{
    public async Task CreateOrderAsync()
    {
        var order = new Order()
        {
            Id = 1,
            Email = "vivek.patel@outamation.com",
            Quantity = 4,
            ProductName = "Atomic Habits Book",
            To = "vivek.patel@outamation.com",
            Subject = "Order created successfully",
            Cc = new List<string>(),
            Bcc = new List<string>(),
            Body = $"Order Id: {1}\nProduct Name: \nQuantity:\nYour order have been received successfully. Soon your order would be dispatched."
        };

        // var email = new Email()
        // {
        //     To = order.Email,
        //     Subject = "Order created successfully",
        //     Cc = new List<string>(),
        //     Bcc = new List<string>(),
        //     Body = $"Order Id: {order.Id}\nProduct Name: {order.ProductName}\nQuantity:{order.Quantity}\nYour order have been received successfully. Soon your order would be dispatched."
        // };

        await PublishCreateOrderAsync(order);
    }

    private async Task PublishCreateOrderAsync(Order order)
    {
        await publishEndpoint.Publish(order);
        // await publishEndpoint.Publish(email);
    }
}