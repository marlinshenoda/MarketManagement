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
        public async Task AddNewProductAsync(CreateProductViewModel data)
        {
            var newProduct = new Product()
            {
                Name = data.ProductName,
                Quantity = data.ProductQuantity,
                Price = data.ProductPrice,
                CategoryId = data.CategoryId,
                Id = data.Id,              
            };
            await _context.Product.AddAsync(newProduct);
            await _context.SaveChangesAsync();

       
        }

        public async Task EditNewProductAsync(CreateProductViewModel data)
        {
            var product  = await _context.Product.FirstOrDefaultAsync(n=>n.Id == data.Id);
            if (product != null)
            {
                product.Name = data.ProductName;
                product.Quantity = data.ProductQuantity;
                product.Price = data.ProductPrice;
                product.CategoryId = data.CategoryId;
                product.Id = data.Id;
                product.CategoryId= data.CategoryId;
                await _context.SaveChangesAsync();
            }
        }
    }

}
