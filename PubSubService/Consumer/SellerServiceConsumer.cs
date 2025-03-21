﻿using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Consumer;

public class SellerServiceConsumer : IConsumer<IOrder>
{
    public async Task Consume(ConsumeContext<IOrder> context)
    {
        Console.WriteLine($"[Seller Service]: Seller received order.");
    }
}