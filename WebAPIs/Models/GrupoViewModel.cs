namespace WebAPIs.Models
{
    public class GrupoViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int IdTorneio { get; set; }
        public int IdTime { get; set; }
        public int Partidas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Pontos { get; set; }
        public string UserId { get; set; }
    }
}
