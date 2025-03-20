using MassTransit;
using PubSubDemo.Queues;

namespace PubSubDemo.Consumer;

public class EmailServiceConsumer : IConsumer<IEmail>
{
    public async Task Consume(ConsumeContext<IEmail> context)
    {
        var email = context.Message;
        Console.WriteLine($"To: {email.To}\nCc: {string.Join(",", email.Cc)}\nBcc:{string.Join(",", email.Bcc)}\nSubject: {email.Subject}\nBody: {email.Body}");
        Console.WriteLine($"[Email Service]: Sent successfully.");
    }
}