using Microsoft.EntityFrameworkCore;

namespace ProjetoPagueMenos.Models
{
    public class Contexto :DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Loja> Lojas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .HasOne(x => x.Loja)
                .WithMany(x => x.Produtos);
        }
    }
}
