
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPagueMenos.Models;

namespace crudFarmaciaPagueMenos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojasController : ControllerBase
    {

        private readonly Contexto _contexto;

        public LojasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<LojasController>
        [HttpGet("ListarLojas")]
        public async Task<ActionResult<IEnumerable<Loja>>> ListarLojas()
        {
            if (_contexto.Lojas == null)
            {
                return NotFound();
            }
            return await _contexto.Lojas.ToListAsync();
        }

        // GET api/<LojasController>/5
        [HttpGet("BuscarLoja/{id}")]
        public async Task<ActionResult<Loja>> BuscarLoja(int id)
        {
            if (_contexto.Lojas == null)
            {
                return NotFound();
            }
            var loja = await _contexto.Lojas.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }

            return loja;
        }

        // POST api/<LojasController>
        [HttpPost("CadastrarLoja")]
        public async Task<ActionResult<Loja>> CadastrarLoja(Loja loja)
        {
            _contexto.Lojas.Add(loja);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarLoja), new { id = loja.Id }, loja);
        }

        // PUT api/<LojasController>/5
        [HttpPut("AtualizarLoja/{id}")]
        public async Task<ActionResult<Loja>> AtualizarLoja(int id, Loja loja)
        {
            if (id != loja.Id)
            {
                return BadRequest();
            }
            _contexto.Entry(loja).State = EntityState.Modified;
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LojaExits(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE api/<LojasController>/5
        [HttpDelete("DeletarLoja/{id}")]
        public async Task<ActionResult> DeletarLoja(int id)
        {
            if (_contexto.Lojas == null)
            {
                return NotFound();
            }
            var loja = await _contexto.Lojas.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }
            _contexto.Lojas.Remove(loja);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool LojaExits(long id)
        {
            return (_contexto.Lojas?.Any(x => x.Id == id)).GetValueOrDefault();
        }
    }

}

