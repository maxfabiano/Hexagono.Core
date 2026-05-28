using Hexagono.Core.CQRS.Commands;
using Hexagono.Core.CQRS.Handlers;
using Hexagono.Core.Ports.Inbound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagono.Core.Ports.Inbound
{
    public class MathInboundAdapter : IMathInboundPort
    {
        private readonly CalcularCommandHandler _handler;

        public MathInboundAdapter(CalcularCommandHandler handler)
        {
            _handler = handler;
        }

        public async Task<decimal> ExecutarCalculoAsync(ICalcularCommand comando)
        {
            // O adaptador apenas repassa a ordem de forma segura para o executor do CQRS
            return await _handler.HandleAsync(comando);
        }
    }
}
