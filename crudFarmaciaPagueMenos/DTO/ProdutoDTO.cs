using ProjetoPagueMenos.Models;

namespace crudFarmaciaPagueMenos.DTO
{
    public class ProdutoDTO{

        public ProdutoDTO() { }
        public ProdutoDTO(Produto produto,decimal desconto) {
            Nome= produto.Nome;
            Estoque= produto.Estoque;
            Preco= produto.Preco;
            ValorDesconto = Preco * desconto;
            PrecoComDesconto = Preco - ValorDesconto;
        }

        public string? Nome { get; set; }

        public int Estoque { get; set; }

        public decimal Preco { get; set; }

        public decimal ValorDesconto { get; set; }

        public decimal PrecoComDesconto { get; set; }

        public int? LojaId { get; set; }
    }
}
