using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPagueMenos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crudFarmaciaPagueMenos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly Contexto _contexto;

        public ProdutosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>>ListarProdutos()
        {
            if (_contexto.Produto == null)
            {
                return NotFound();
            }
            return await _contexto.Produto.ToListAsync();
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarProduto(int id)
        {
            if (_contexto.Produto == null)
            {
                return NotFound();
            }
            var produto = await _contexto.Produto.FindAsync(id);

            if(produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<ActionResult<Produto>> CadastrarProduto(Produto produto){
            _contexto.Produto.Add(produto);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarProduto), new {id=produto.Id},produto);   
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> AtualizarProduto(int id,Produto produto)
        {
            if(id!= produto.Id)
            {
                return BadRequest();
            }
            _contexto.Entry(produto).State= EntityState.Modified;
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ProdutoExits(id))
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

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            if(_contexto.Produto==null)
            {
                return NotFound();
            }
            var produto = await _contexto.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }
            _contexto.Produto.Remove(produto);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExits(long id)
        {
            return (_contexto.Produto?.Any(x => x.Id == id)).GetValueOrDefault();
        }
    }
}
