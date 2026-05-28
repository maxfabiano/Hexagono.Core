using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagono.Core.CQRS.Commands
{
    public interface ICalcularCommand
    {
        decimal PrimeiroNumero { get; }
        decimal SegundoNumero { get; }
        string Operacao { get; } // "somar", "subtrair", "multiplicar"
    }
}
