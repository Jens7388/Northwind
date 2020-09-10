﻿using Microsoft.EntityFrameworkCore;
using NT.DataAccess.RepositoryBase;
using NT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.DataAccess.Repos
{
    public class ProductRepository : RepositoryBase<Products>
    {
        public override async Task<Products> GetByAsync(int id)
        {
            return await context.Products
                .Include("Category")
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public override async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await context.Set<Products>()
                .Include("Category")
                .ToListAsync();
        }
    }
}
