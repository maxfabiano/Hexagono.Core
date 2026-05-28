using Hexagono.Core.CQRS.Commands;
using Hexagono.Core.CQRS.Handlers;
using Hexagono.Core.Ports.Inbound;
using Hexagono.Core.Ports.Inbound.Interfaces;
using Infra.Mensageria;
using Solucao.Api.Controllers;
using Utils.DependencyInjection; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================================================================
// INJEÇÃO DE DEPENDÊNCIAS (O Composition Root)
// =====================================================================

// 1. Liga o motor do Coração
builder.Services.AddScoped<CalcularCommandHandler>();

// 2. Liga a Porta de Entrada ao Motor
builder.Services.AddScoped<IMathInboundPort, MathInboundAdapter>();
// 3. Liga o Lado Utilitário (Sem expor o MathUtilsService aqui)
builder.Services.AddLadoCalculadoraUtils();
// Exemplo no Program.cs
builder.Services.AddInfraMensageria(builder.Configuration, x =>
{
    // O MassTransit precisa registrar este comando como um contrato de requisição.
    // Sem isso, o DI não sabe como injetar o IRequestClient<CalcularCommand>
    x.AddRequestClient<CalcularCommand>();
});

var app = builder.Build();

// =====================================================================
// O LADO HTTP (Adaptador de Entrada)
// =====================================================================


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();