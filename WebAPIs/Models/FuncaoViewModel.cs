﻿namespace WebAPIs.Models
{
    public class FuncaoViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UserId { get; set; }

    }
}
