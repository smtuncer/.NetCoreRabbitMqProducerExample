using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

// connectionFactory --> Connection ---> Channel 
var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
    //If you want to remote connection 
    //Uri = new Uri(""),
    //UserName = "",
    //Password = "",
};
var connection = connectionFactory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare(queue: "Test", durable: false, exclusive: false, autoDelete: false, arguments: null);

var message = "Message";
var byteMessage = Encoding.UTF8.GetBytes(message);
channel.BasicPublish(exchange: "", routingKey: "Test", basicProperties: null, body: byteMessage);

Console.WriteLine("Message Sent");

Console.ReadKey();