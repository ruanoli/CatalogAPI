using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {
      
        private readonly AppDbContext? _context;
        public ProdutosController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() {
            try {
                var produtos = await _context.Produtos
                .Where(x => x.Id <= 10)
                .AsNoTracking()
                .ToListAsync();

                if (produtos is null)
                    return NotFound("Produtos não encontrados.");

                return Ok(produtos);
            } catch {
                return StatusCode(500, "Erro interno no servidor");
            }
        }
        [HttpGet("{id:int}", Name ="ObterProduto")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            try {
                var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (produto is null)
                    return NotFound("Produto não encontrado");

                return Ok(produto);
            } catch {
                return StatusCode(500, "Erro interno no servidor.");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Produto produto) {
            try {
                if (produto is null)
                    return BadRequest();

                _context.Entry(produto).State = EntityState.Added;
                await _context.SaveChangesAsync();

                return Created($"ObterProduto/{produto.Id}", produto);
            } catch {
                return StatusCode(500, "Erro interno no servidor.");
            }
            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, Produto produto) {
            try {
                if (id != produto.Id)
                    return BadRequest($"Produto de id {id} não existe.");

                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(produto);
            }
            catch{
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync(int id) {
            try {
                var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto is null)
                    return NotFound();

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                return Ok(produto);
            } catch {
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}
