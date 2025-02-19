namespace PubSubDemo.Queues;

public interface IOrderDispatch
{
    public int OrderId { get; }
    public string DeliveryAddress { get; }
    public string PickupAddress { get; }
    public int DeliveryPartnerId { get; }
}