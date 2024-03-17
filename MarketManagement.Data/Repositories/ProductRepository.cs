using MarketManagement.Core.Entities;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Data.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {

    
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

   
    }

}
