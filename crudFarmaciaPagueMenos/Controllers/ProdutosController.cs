using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        [HttpGet("BuscarProduto")]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarProduto()
        {
            if (_contexto.Produtos == null)
            {
                return NotFound();
            }
            return await _contexto.Produtos.ToListAsync();
        }

        // GET api/<ProdutosController>/5
        [HttpGet("BuscarProduto/{id}")]
        public async Task<ActionResult<Produto>> BuscarProduto(int id)
        {
            if (_contexto.Produtos == null)
            {
                return NotFound();
            }
            var produto = await _contexto.Produtos
                .Include(x => x.Loja)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // GET api/<ProdutosController>/5
        [HttpGet("BuscarProdutoPorLoja/{id}")]
        public async Task<ActionResult<List<Produto>>> BuscarProdutoPorLoja(int id)
        {
            return _contexto.Produtos
                .FromSqlInterpolated($"SELECT * From Produtos Where LojaId = {id}")
                .ToList();
        }

        // POST api/<ProdutosController>
        [HttpPost(" CadastrarProduto")]
        public async Task<ActionResult<Produto>> CadastrarProduto(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarProduto), new { id = produto.Id }, produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("AtualizarProduto/{id}")]
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
        [HttpDelete("DeletarProduto/{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            if(_contexto.Produtos==null)
            {
                return NotFound();
            }
            var produto = await _contexto.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }
            _contexto.Produtos.Remove(produto);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExits(long id)
        {
            return (_contexto.Produtos?.Any(x => x.Id == id)).GetValueOrDefault();
        }
    }
}
