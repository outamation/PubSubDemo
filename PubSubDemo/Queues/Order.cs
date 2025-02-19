namespace PubSubDemo.Queues;

public class Order : IOrder, IEmail
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Email { get; set; }
    public string To { get; set; }
    public List<string>? Cc { get; set; }
    public List<string>? Bcc { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}