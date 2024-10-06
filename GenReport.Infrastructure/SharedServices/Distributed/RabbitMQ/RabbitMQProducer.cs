using GenReport.Infrastructure.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Mime;
using Serilog;


namespace GenReport.Infrastructure.SharedServices.Distributed.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly IApplicationConfiguration _appConfig;
        private readonly ConnectionFactory _connectionFactory;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public RabbitMQProducer(IApplicationConfiguration _appConfig)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = _appConfig.RabbitMQConfiguration.HostName,
                UserName = _appConfig.RabbitMQConfiguration.UserName,
                Password = _appConfig.RabbitMQConfiguration.Password,
                ClientProvidedName = _appConfig.RabbitMQConfiguration.ClientProvidedName
            };
        } 

        public bool ProduceMessage<T>(T message,string exchange, string queue)
        {
            try
            {
                var conn = _connectionFactory.CreateConnection();
                IModel channel = conn.CreateModel();
                channel.BasicPublish(exchange,queue,true,GetDefaultProperties(channel),new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message))));
                return true;
            }
            catch (Exception e)
            {
                Log.Error(e, $"Error executing {nameof(ProduceMessage)} {e.Message}");
                throw;
            }
        }
        public async Task<bool> ProduceMessageAsync<T>(T message, string exchangeName, string routingKey)
        {
          return  await Task.Run(() => { return ProduceMessage(message,exchangeName,routingKey); });
        }
        public bool ProduceBatchMessages<T>(List<T> messages, string exchangeName, string routingKey)
        {
            
            var conn = _connectionFactory.CreateConnection();
            IModel channel = conn.CreateModel();
            IBasicPublishBatch batch = channel.CreateBasicPublishBatch();
            IBasicProperties basicProperties = GetDefaultProperties(channel);
            try
            {
                foreach (var message in messages)
                {
                    batch.Add(exchangeName, routingKey, true, basicProperties , new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message))));
                }

                batch.Publish();
                return true;
            }
            catch (Exception e)
            {
                Log.Error(e, $"Error executing {nameof(ProduceBatchMessages)} {e.Message}");
                throw;
            }

        }

        private IBasicProperties GetDefaultProperties(IModel channel , string contentType = "application/json")
        {
           IBasicProperties basicProperties =  channel.CreateBasicProperties();
            basicProperties.ContentType = contentType;
            basicProperties.DeliveryMode = 1;
            return basicProperties;
        }
    }
}
