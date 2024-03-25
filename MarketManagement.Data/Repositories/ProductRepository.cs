using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
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
        private readonly ApplicationDbContext _context;


        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

    }

}
