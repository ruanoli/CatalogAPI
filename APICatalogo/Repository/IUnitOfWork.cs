namespace APICatalogo.Repository
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository ICategoriaRepository { get; }
        void Commit(); //método de persistência no banco
    }
}
