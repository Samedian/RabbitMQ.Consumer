using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Consumer
{
    public static class QueueConsumer
    {
        public static void Consumer(IModel channel)
        {
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
            Console.WriteLine("Consumer started");


        }
    }
}
