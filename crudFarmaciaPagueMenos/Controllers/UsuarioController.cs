using crudFarmaciaPagueMenos.DTO;
using crudFarmaciaPagueMenos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPagueMenos.Models;

namespace crudFarmaciaPagueMenos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Contexto _contexto;

        public UsuarioController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET api/<ProdutosController>/5
        [HttpGet("BuscarUsuario/{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuario(int id)
        {
            if (_contexto.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _contexto.Usuarios
                .Include(x => x.Desconto)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST api/<ProdutosController>
        [HttpPost("CadastrarUsuario")]
        public async Task<ActionResult<Produto>> CadastrarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(BuscarUsuario), new { id = usuario.Id }, usuario);
        }
    }
}