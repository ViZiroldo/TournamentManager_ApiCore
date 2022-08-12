using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("Jogos")]
    public  class Jogos: Notifies
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("IdTorneio")]
        [ForeignKey("Torneio")]
        public int IdTorneio { get; set; }

        [Column("IdGrupo")]
        [ForeignKey("Grupo")]
        public int IdGrupo { get; set; }

        [Column("Time1")]
        [ForeignKey("Time")]
        public int Time1 { get; set; }

        [Column("Time2")]
        [ForeignKey("Time")]
        public int Time2 { get; set; }

        [Column("TimeVencedor")]
        [ForeignKey("Time")]
        public int TimeVencedor { get; set; }

        [Column("Placar")]
        public string Placar { get; set; }

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
