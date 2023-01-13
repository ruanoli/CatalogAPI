﻿using APICatalogo.Context;

namespace APICatalogo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository _produtoRepository;
        private CategoriaRepository _categoriaRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICategoriaRepository ICategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
