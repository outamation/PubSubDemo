namespace PubSubDemo.Queues;

public interface IOrder
{
    public int Id { get; }
    public string ProductName { get; }
    public int Quantity { get; }
    public string Email { get; }
}