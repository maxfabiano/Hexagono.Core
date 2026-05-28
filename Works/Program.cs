using Infra.Mensageria;
using Utils.DependencyInjection;
using Works;
var builder = Host.CreateApplicationBuilder(args);

// 1. Registro do Domínio (Regras de negócio)
builder.Services.AddDomainServices();
builder.Services.AddLadoCalculadoraUtils();
// 2. Registro da Infraestrutura (Mensageria)
builder.Services.AddInfraMensageria(builder.Configuration, x =>
{
    // Registra os consumidores aqui (dentro da aplicação que os utiliza)
    x.AddConsumer<CalcularCommandConsumer>();
});

var host = builder.Build();
host.Run();