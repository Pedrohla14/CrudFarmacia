using ProjetoPagueMenos.Models;
using System.ComponentModel.DataAnnotations;

namespace crudFarmaciaPagueMenos.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public int? DescontoId { get; set; }
        public virtual Desconto? Desconto { get; set; }

    }
}
