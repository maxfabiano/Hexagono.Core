
using Hexagono.Core.Ports.Inbound.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hexagono.Core.Ports.Outbound.Interfaces
{
    public interface ISolucaoApiOutboundPort
    {
        Task<IActionResult> Calcular(CalcularRequestDto request, IMathInboundPort portaDeEntrada);
    }
}
