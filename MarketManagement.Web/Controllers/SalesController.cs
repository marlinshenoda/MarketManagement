using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using MarketManagement.Data.Repositories;
using MarketManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketManagement.Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _service;
        private readonly ICategoryRepository _categoryRepository;

        public SalesController(ApplicationDbContext context, IProductRepository service, ICategoryRepository categoryRepository) 
        {
            _context = context;
            _service = service;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = await _categoryRepository.GetAllAsync(),
                Products = await _service.GetAllAsync()
            };
            return View(salesViewModel);
        }
        public async Task<IActionResult> GetProductsByCategoryIdAjax(int? Id)
        {
            if (Id == null) return BadRequest();

            if (Request.IsAjax())
            {
                //   var products=_context.Product.AnyAsync
         //       var module = await db.Modules.FirstOrDefaultAsync(m => m.Id == id);

                var categoryId = await _context.Category.FirstOrDefaultAsync(m => m.Id == Id);
                var products = await _context.Product
                   .Where(m => m.Id == Id).Select(a => new SalesViewModel
                   {
                       ProductName = a.Name,
                       ProductQuentity = (int)a.Quantity
                   }).ToListAsync();
                 return View(products);
            }
            return BadRequest();

        }
    }
}
