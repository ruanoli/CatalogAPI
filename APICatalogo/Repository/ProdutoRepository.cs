
using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context) : base (context)
    {
    }

    public IEnumerable<Produto> GetProdutosPorPreco()
    {
        return GetAll().OrderBy(x => x.Preco).ToList();
    }
}