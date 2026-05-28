
using MassTransit;
using Hexagono.Core.Ports.Outbound.Interfaces;

namespace Infra.Mensageria
{

    public class RabbitMQProducerAdapter : IMessageProducerPort
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMQProducerAdapter(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync<T>(string topic, T message)
        {
            // O MassTransit envia a mensagem. Ele cuida da serialização JSON.
            await _publishEndpoint.Publish(message);
        }
    }
}
