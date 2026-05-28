

using Hexagono.Core.CQRS.Commands;

namespace Hexagono.Core.Ports.Inbound.Interfaces
{
    public interface IMathInboundPort
    {
        Task<decimal> ExecutarCalculoAsync(ICalcularCommand comando);
    }
}
