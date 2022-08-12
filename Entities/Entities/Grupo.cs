using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("Grupo")]
    public  class Grupo : Notifies
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("IdTornio")]
        [ForeignKey("Torneio")]
        public int IdTorneio { get; set; }

        [Column("IdTime")]
        [ForeignKey("Time")]
        public int IdTime { get; set; }

        [Column("Partidas")]
        public int Partidas { get; set; }

        [Column("Vitorias")]
        public int Vitorias { get; set; }

        [Column("Derrotas")]
        public int Derrotas { get; set; }

        [Column("Pontos")]
        public int Pontos { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
