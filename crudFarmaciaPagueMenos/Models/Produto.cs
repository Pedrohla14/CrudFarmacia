
using crudFarmaciaPagueMenos.DTO;
using crudFarmaciaPagueMenos.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPagueMenos.Models
{
   
    public class Produto
    {
        public Produto() { }

        public Produto(ProdutoDTO produtoDTO)
        {
            this.Nome = produtoDTO.Nome;
            this.Estoque = produtoDTO.Estoque;
            this.Preco = produtoDTO.Preco;
            this.LojaId = produtoDTO.LojaId;
        }

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
