
using System.ComponentModel.DataAnnotations;

namespace ProjetoPagueMenos.Models
{
   
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public int Estoque { get; set; }

        public decimal Preco { get; set; }

        //One-to-many
        public int? LojaId { get; set; }
        public virtual Loja? Loja { get; set; }
    }
}
