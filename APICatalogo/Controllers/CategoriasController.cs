using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APICatalogo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase {
        private readonly AppDbContext? _context;

        public CategoriasController(AppDbContext? context) { 
            _context = context;
        }
        [HttpGet("produtos")]
        public async Task<IActionResult> GetCategoriasEProdutosAsync() {
            return Ok(await _context.Categorias.Include(x => x.Produtos)
                .Where(x => x.Id  <= 10)
                .AsNoTracking()
                .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() {
           var categoria = await _context.Categorias
                .Where(x => x.Id <= 10)
                .AsNoTracking()
                .ToListAsync();

            if(categoria is null)
                return NotFound("Produtos não encontrado.");

            return Ok(categoria); 
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            var categoria = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (categoria is null)
                return NotFound();

            return Ok(categoria); 
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Categoria categoria) {
            if (categoria is null)
                return NotFound();

            _context.Entry(categoria).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return Created($"ObterCategoria/{categoria.Id}", categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, Categoria categoria) {
            if(id != categoria.Id)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
            
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
            
            if(categoria is null)
                return NoContent();

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }
    }
}
