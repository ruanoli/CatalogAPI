﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base (context) { }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return GetAll().Include(x => x.Produtos);
        }
    }
}
