using MassTransit;
using mensageria.Relatorios;

namespace mensageria.Controllers
{
    internal static class ApiEndpoints
    {
        public static void AddApiEndPoints(this WebApplication app)
        {
            app.MapPost("solicitar-relatorio/{name}", async (string name, IBus bus) =>
            {
                var solicitacao = new SolicitacaoRelatorio()
                {
                    Id = new Guid(),
                    Name = name,
                    Status = "Pendente",
                    ProcessedTime = null
                };

                Lista.Relatorios.Add(solicitacao);

                var eventRequest = new RelatorioSolicitadoEvent(solicitacao.Id, solicitacao.Name);

                await bus.Publish(eventRequest);

                return Results.Ok(solicitacao);
            });

            app.MapGet("relatorios", () => Lista.Relatorios);
        }
    }
}
