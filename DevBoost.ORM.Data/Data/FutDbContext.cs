using DevBoost.ORM.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBoost.ORM.Data.Data
{
    public class FutDbContext : DbContext
    {
        public FutDbContext(DbContextOptions<FutDbContext> options) : base(options)
        {
        }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<Clube> Clubes { get; set; }
    }
}
