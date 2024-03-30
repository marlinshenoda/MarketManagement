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
                Categories = await _categoryRepository.GetAllAsync()
            };
            return View(salesViewModel);
        }
        public async Task<IActionResult> GetProductsByCategoryIdAjax(int categoryId)
        {
            if (categoryId == null) return BadRequest();

            if (Request.IsAjax())
            {
                var products = _context.Product.Where(x => x.CategoryId == categoryId).ToList();
                 return PartialView("_Products", products);
            }
            return BadRequest();

        }
    }
}
