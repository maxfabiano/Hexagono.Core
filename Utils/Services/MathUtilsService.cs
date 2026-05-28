using Hexagono.Core.Ports.Outbound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Services
{
    public class MathUtilsService : IMathOutboundPort
    {
        public decimal Somar(decimal a, decimal b) => a + b;

        public decimal Subtrair(decimal a, decimal b) => a - b;

        public decimal Multiplicar(decimal a, decimal b) => a * b;
    }
}
