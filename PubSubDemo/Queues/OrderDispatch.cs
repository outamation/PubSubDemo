namespace PubSubDemo.Queues;

public class OrderDispatch : IOrderDispatch
{
    public int OrderId { get; set; }
    public string DeliveryAddress { get; set; }
    public string PickupAddress { get; set; }
    public int DeliveryPartnerId { get; set; }
}