namespace WebAPIs.Models
{
    public class TorneioViewModel
    {

        public int Id { get; set; }
        public string NomeTorneio { get; set; }
        public bool Ativo { get; set; }
        public decimal Premiacao { get; set; }
        public int TotalParticipantes { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string? UserId { get; set; }
        public int TotalGrupo { get; set; }
    }
}
