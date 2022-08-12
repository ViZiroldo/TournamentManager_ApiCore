namespace WebAPIs.Models
{
    public class JogosViewModel
    {

        public int Id { get; set; }
        public int IdTorneio { get; set; }
        public int IdGrupo { get; set; }
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int TimeVencedor { get; set; }
        public string Placar { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
