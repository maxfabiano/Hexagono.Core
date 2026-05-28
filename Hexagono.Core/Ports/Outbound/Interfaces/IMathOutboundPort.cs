
namespace Hexagono.Core.Ports.Outbound.Interfaces
{
    public interface IMathOutboundPort
    {
        decimal Somar(decimal a, decimal b);
        decimal Subtrair(decimal a, decimal b);
        decimal Multiplicar(decimal a, decimal b);
    }
}
