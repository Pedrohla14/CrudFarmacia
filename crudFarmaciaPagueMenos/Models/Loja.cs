
using System.ComponentModel.DataAnnotations;

namespace ProjetoPagueMenos.Models
{

    public class Loja
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

        public List<Produto>? Produtos { get; set; } 
    }
}
