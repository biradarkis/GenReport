using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.Infrastructure.SharedServices.Distributed.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public bool ProduceMessage<T>(T message, string exchangeName, string routingKey);
        public Task<bool> ProduceMessageAsync<T>(T message, string exchangeName, string routingKey);
    }
}
