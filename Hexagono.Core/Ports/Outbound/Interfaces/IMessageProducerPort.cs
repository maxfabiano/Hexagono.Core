using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagono.Core.Ports.Outbound.Interfaces
{
    public interface IMessageProducerPort
    {
        Task PublishAsync<T>(string topic, T message);
    }
}
