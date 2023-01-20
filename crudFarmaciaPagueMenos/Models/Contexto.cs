using crudFarmaciaPagueMenos.Models;
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

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Desconto> Descontos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .HasOne(x => x.Loja)
                .WithMany(x => x.Produtos);

            builder.Entity<Usuario>()
             .HasOne(x => x.Desconto)
             .WithMany(x => x.Usuarios);
        }
    }
}
