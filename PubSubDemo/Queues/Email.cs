namespace PubSubDemo.Queues;

public class Email : IEmail
{
    public string To { get; set;  }
    public List<string>? Cc { get; set; }
    public List<string>? Bcc { get; set; }
    public string Subject { get; set;  }
    public string Body { get; set; }
}