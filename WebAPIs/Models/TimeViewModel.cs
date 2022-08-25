namespace WebAPIs.Models
{
    public class TimeViewModel
    {

        public int Id { get; set; }
        public string NomeTime { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
