using mensageria.Relatorios;

namespace mensageria.Controllers
{
    internal static class ApiEndpoints
    {
        public static void AddApiEndPoints(this WebApplication app)
        {
            app.MapPost("solicitar-relatorio/{name}", (string name) =>
            {
                var solicitacao = new SolicitacaoRelatorio()
                {
                    Id = new Guid(),
                    Name = name,
                    Status = "Pendente",
                    ProcessedTime = null
                };

                Lista.Relatorios.Add(solicitacao);

                return Results.Ok(solicitacao);
            });

            app.MapGet("relatorios", () => Lista.Relatorios);
        }
    }
}
