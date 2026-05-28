using Utils.Services;
using Hexagono.Core.Ports.Outbound.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Utils.DependencyInjection;

public static class UtilsExtensions
{
    public static IServiceCollection AddLadoCalculadoraUtils(this IServiceCollection services)
    {
        // O próprio projeto Utils faz o vínculo com a porta do Coração
        services.AddScoped<IMathOutboundPort, MathUtilsService>();

        return services;
    }
}