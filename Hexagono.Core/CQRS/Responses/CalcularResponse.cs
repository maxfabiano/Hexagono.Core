namespace Hexagono.Core.CQRS.Responses
{
    public record CalcularResponse(decimal Resultado, bool Sucesso, string Mensagem);
}