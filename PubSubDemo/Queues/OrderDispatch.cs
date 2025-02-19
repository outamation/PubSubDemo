namespace PubSubDemo.Queues;

public class OrderDispatch : IOrderDispatch, IEmail
{
    public int OrderId { get; set; }
    public string DeliveryAddress { get; set; }
    public string PickupAddress { get; set; }
    public int DeliveryPartnerId { get; set; }
    public string Email { get; set; }
    public string To { get; set; }
    public List<string>? Cc { get; set; }
    public List<string>? Bcc { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}