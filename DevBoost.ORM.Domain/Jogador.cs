using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevBoost.ORM.Domain
{
    public class Jogador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public int Idade { get; set; }

        [ForeignKey("Posicao")]
        public int PosicaoId { get; set; }
        public Posicao Posicao { get; set; }

        [ForeignKey("Clube")]
        public int ClubeId { get; set; }
        public virtual Clube Clube { get; set; }


    }
}
