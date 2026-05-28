using Hexagono.Core.CQRS.Handlers;
using Hexagono.Core.Ports.Inbound;
using Hexagono.Core.Ports.Inbound.Interfaces;
using Hexagono.Core.Ports.Outbound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Works
{
    // Dentro do projeto Works: Crie um arquivo ApplicationExtensions.cs
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<CalcularCommandHandler>();
            services.AddScoped<IMathInboundPort, MathInboundAdapter>();
            return services;
        }
    }
}
