using Hexagono.Core.CQRS.Commands;
using Hexagono.Core.Ports.Outbound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagono.Core.CQRS.Handlers
{
    public class CalcularCommandHandler
    {
        private readonly IMathOutboundPort _mathOutbound;

        // O coração exige que alguém implemente a porta de saída e passe para ele aqui
        public CalcularCommandHandler(IMathOutboundPort mathOutbound)
        {
            _mathOutbound = mathOutbound;
        }

        public Task<decimal> HandleAsync(ICalcularCommand comando)
        {
            decimal resultado = comando.Operacao.ToLower() switch
            {
                "somar" => _mathOutbound.Somar(comando.PrimeiroNumero, comando.SegundoNumero),
                "subtrair" => _mathOutbound.Subtrair(comando.PrimeiroNumero, comando.SegundoNumero),
                "multiplicar" => _mathOutbound.Multiplicar(comando.PrimeiroNumero, comando.SegundoNumero),
                _ => throw new InvalidOperationException("Operação matemática não suportada.")
            };

            return Task.FromResult(resultado);
        }
    }
}
