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
            //QueueConsumer.Consumer(channel);
            //DirectExchangeConsumer.Consume(channel);
            //TopicExchangeConsumer.Consume(channel);
            //HeaderExchangeConsumer.Consume(channel);
            FanoutExchangeConsumer.Consume(channel);

            Console.ReadLine();
        }
    }
}
