O Fluxo Correto (Request/Response)
API (O Lado HTTP):

Recebe o POST do usuário.

O IRequestClient (configurado no seu Program.cs) empacota o CalcularCommand.

Envia para a fila CalcularCommand no RabbitMQ.

A API fica parada, esperando uma resposta (por isso o timeout se ninguém responder).

RabbitMQ:

Apenas guarda a mensagem na fila CalcularCommand.

Worker (O Lado do Processamento):

O MassTransit (que está rodando lá dentro) vê que chegou uma mensagem.

Ele chama o CalcularCommandConsumer.

AQUI ESTÁ O "CORAÇÃO": O Consumer não envia para outra fila. Ele chama o seu IMathInboundPort (que é uma interface do seu Core/Domínio).

O MathInboundAdapter (que está dentro do Worker) chama o CalcularCommandHandler (o Coração).

O CalcularCommandHandler chama o Utils (o lado utilitário) e faz o cálculo.

O cálculo termina e o CommandHandler retorna o resultado para o Consumer.

O Retorno (A "Volta"):

O Consumer pega esse resultado e chama o context.RespondAsync(...).

O MassTransit (via RabbitMQ) entrega esse resultado lá na API, na fila temporária.

A API recebe, "acorda" do await, e devolve o JSON para o usuário.
