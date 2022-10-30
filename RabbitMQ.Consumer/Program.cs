using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            //RabbitMQ.Client used

            //Connection Factory
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            //amqp://username:password:host:port
            using var connection = factory.CreateConnection(); //return iconnection object
            using var channel = connection.CreateModel(); // return imodel nothing but channel
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            // durable true - msg hang around until user reads it

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(message);
            };
            channel.BasicConsume("demo-queue", true, consumer);
            Console.ReadLine();
        }
    }
}
