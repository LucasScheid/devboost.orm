using System.Collections.Generic;

namespace DevBoost.ORM.Domain
{
    public class Clube
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public virtual ICollection<Jogador> Jogadores { get; set; }

    }
}
