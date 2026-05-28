using Hexagono.Core.Ports.Outbound.Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Mensageria
{
    public static class MensageriaExtensions
    {
        /// <summary>
        /// Configura o MassTransit e o RabbitMQ de forma desacoplada.
        /// </summary>
        /// <param name="configureBus">Delegate opcional para registrar consumidores específicos do projeto chamador.</param>
        public static IServiceCollection AddInfraMensageria(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IBusRegistrationConfigurator>? configureBus = null)
        {
            services.AddMassTransit(x =>
            {
                // Se houver uma ação de configuração de bus (para registrar Consumers), ela é executada aqui.
                // Isso permite que cada projeto (Worker, API, etc.) registre seus próprios Consumers.
                configureBus?.Invoke(x);

                x.UsingRabbitMq((context, cfg) =>
                {
                    var host = configuration["RabbitMQ:Host"] ?? "localhost";
                    var user = configuration["RabbitMQ:User"] ?? "admin";
                    var pass = configuration["RabbitMQ:Password"] ?? "senha123";

                    cfg.Host(host, "/", h =>
                    {
                        h.Username(user);
                        h.Password(pass);
                    });

                    // Configura automaticamente os endpoints (filas/exchanges) 
                    // baseados nos consumidores registrados anteriormente.
                    cfg.ConfigureEndpoints(context);
                });
            });

            // Registro do adaptador de mensageria
            services.AddScoped<IMessageProducerPort, RabbitMQProducerAdapter>();

            return services;
        }
    }
}