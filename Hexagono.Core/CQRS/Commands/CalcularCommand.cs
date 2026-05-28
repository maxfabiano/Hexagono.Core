using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagono.Core.CQRS.Commands
{
    public record CalcularCommand(decimal PrimeiroNumero, decimal SegundoNumero, string Operacao) : ICalcularCommand;
}
