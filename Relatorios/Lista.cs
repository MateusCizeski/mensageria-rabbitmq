namespace mensageria.Relatorios
{
    internal static class Lista
    {
        public static List<SolicitacaoRelatorio> Relatorios = new List<SolicitacaoRelatorio>();
    }

    public class SolicitacaoRelatorio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Status { get; set; }
        public DateTime? ProcessedTime { get; set; }
    }
}
