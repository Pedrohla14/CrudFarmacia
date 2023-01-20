using ProjetoPagueMenos.Models;
using System.ComponentModel.DataAnnotations;

namespace crudFarmaciaPagueMenos.Models
{
    public class Desconto
    {
        [Key]
        public int Id { get; set; }

        public string Categoria { get; set; }
        public decimal valor { get; set; }

        public List<Usuario>? Usuarios { get; set; }

    }
}
