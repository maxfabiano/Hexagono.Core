using Hexagono.Core;
using Hexagono.Core.CQRS.Commands;
using Hexagono.Core.CQRS.Responses;
using Hexagono.Core.Ports.Outbound.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Solucao.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private readonly IRequestClient<CalcularCommand> _requestClient;

    public ApiController(IRequestClient<CalcularCommand> requestClient)
    {
        _requestClient = requestClient;
    }

    [HttpPost("calcular")]
    public async Task<IActionResult> Calcular([FromBody] CalcularRequestDto request)
    {
        var comando = new CalcularCommand(request.PrimeiroNumero, request.SegundoNumero, request.Operacao);

        try
        {
            // O código para aqui (aguarda) até o worker responder ou dar timeout
            var response = await _requestClient.GetResponse<CalcularResponse>(comando);

            // Retorna o resultado vindo do Worker direto para o usuário
            return Ok(response.Message);
        }
        catch (RequestTimeoutException)
        {
            return StatusCode(408, "O serviço de cálculo demorou muito para responder.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro ao processar cálculo.");
        }
    }
}