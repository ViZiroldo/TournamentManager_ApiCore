using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("Torneio")]
    public  class Torneio 
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NomeTorneio")]
        public string NomeTorneio { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("Premiacao")]
        public decimal Premiacao { get; set; }

        [Column("TotalParticipantes")]
        public int TotalParticipantes { get; set; }

        [Column("DataInicio")]
        public DateTime DataInicio { get; set; }

        [Column("DataFim")]
        public DateTime DataFim { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Column("TotalGrupo")]
        public int TotalGrupo { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
