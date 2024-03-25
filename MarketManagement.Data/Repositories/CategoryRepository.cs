
using MarketManagement.Core.Entities;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Data.Repositories
{
    public class _categoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public _categoryRepository(ApplicationDbContext context) : base(context) { }

    }
}
