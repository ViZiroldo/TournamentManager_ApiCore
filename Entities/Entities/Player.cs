using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("Player")]
    public  class Player: Notifies
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("IdFuncao")]
        [ForeignKey("Funcao")]
        public int IdFuncao { get; set; }

        [Column("Idade")]
        public int Idade { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Column("IdTime")]
        [ForeignKey("Time")]
        public int IdTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
