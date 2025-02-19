namespace PubSubDemo.Queues;

public interface IEmail
{
    public string To { get;  }
    public List<string>? Cc { get; }
    public List<string>? Bcc { get; }
    public string Subject { get; }
    public string Body { get;  }
}