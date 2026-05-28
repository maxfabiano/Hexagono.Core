// Infra.Kafka/KafkaProducerAdapter.cs
using Confluent.Kafka;
using Hexagono.Core.Ports.Outbound.Interfaces;
using System.Text.Json;

public class KafkaProducerAdapter : IMessageProducerPort
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducerAdapter()
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task PublishAsync<T>(string topic, T message)
    {
        var json = JsonSerializer.Serialize(message);
        await _producer.ProduceAsync(topic, new Message<string, string> { Value = json });
    }
}