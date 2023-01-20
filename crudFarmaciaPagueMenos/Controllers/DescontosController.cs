using crudFarmaciaPagueMenos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPagueMenos.Models;

namespace crudFarmaciaPagueMenos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescontosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public DescontosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET api/<ProdutosController>/5
        [HttpGet("BuscarDescontos/{id}")]
        public async Task<ActionResult<Desconto>> BuscarDesconto(int id)
        {
            if (_contexto.Descontos == null)
            {
                return NotFound();
            }
            var desconto = await _contexto.Descontos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (desconto == null)
            {
                return NotFound();
            }

            return desconto;
        }

        // POST api/<ProdutosController>
        [HttpPost("CadastrarDescontos")]
        public async Task<ActionResult<Desconto>> CadastrarUsuario([FromBody] Desconto desconto)
        {
            _contexto.Descontos.Add(desconto);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(BuscarDesconto), new { id = desconto.Id }, desconto);
        }
    }
}
