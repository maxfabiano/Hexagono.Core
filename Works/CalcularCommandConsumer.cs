using Hexagono.Core.CQRS.Commands;
using Hexagono.Core.CQRS.Responses;
using Hexagono.Core.Ports.Inbound.Interfaces;
using MassTransit;

namespace Works;

public class CalcularCommandConsumer : IConsumer<CalcularCommand>
{
    private readonly IMathInboundPort _portaDeEntrada;

    public CalcularCommandConsumer(IMathInboundPort portaDeEntrada)
    {
        _portaDeEntrada = portaDeEntrada;
    }

    public async Task Consume(ConsumeContext<CalcularCommand> context)
    {

        // 1. Executa a regra de negócio
        var resultado = await _portaDeEntrada.ExecutarCalculoAsync(context.Message);

        // 2. Envia a resposta de volta para a API (que está esperando)
        await context.RespondAsync(new CalcularResponse(
            Resultado: resultado,
            Sucesso: true,
            Mensagem: "Cálculo realizado com sucesso"
        ));
    }
}