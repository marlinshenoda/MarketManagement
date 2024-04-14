using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using MarketManagement.Data.Repositories;
using MarketManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MarketManagement.Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _service;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;

        public SalesController(ApplicationDbContext context, IProductRepository service, ICategoryRepository categoryRepository,ITransactionRepository transactionRepository) 
        {
            _context = context;
            _service = service;
            _categoryRepository = categoryRepository;
            _transactionRepository= transactionRepository;
        }
        public async Task<IActionResult> Index()
        {
         
            return View();
        }

    

        public async Task<IActionResult> GetProductsByCategoryIdAjax(int SelectedCategoryId)
        {
          
            var products = await _context.Product
               .Where(a => a.CategoryId == SelectedCategoryId).ToListAsync();

            return PartialView("_Products", products);


        }
        public async Task<IActionResult> GetProductsDetailsAjax(int Id)
        {

            var Details = await _service.GetByIdAsync(Id);

            return PartialView("_SellProduct", Details);

        }
        
        public async Task<IActionResult> Sell( SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product
                var product = await _service.GetByIdAsync(salesViewModel.SelectedProductId);
                if (product != null)
                {
                  await  _transactionRepository.Add("Cashier 1",
                        salesViewModel.SelectedProductId,
                        product.Name,
                        product.Price.HasValue ? product.Price.Value : 0,
                        product.Quantity.HasValue ? product.Quantity.Value : 0,
                        salesViewModel.QuantityToSell
                );
                    product.Quantity -= salesViewModel.QuantityToSell;
                  await  _service.UpdateAsync(salesViewModel.SelectedProductId, product);

                }
                var prod = await _service.GetByIdAsync(salesViewModel.SelectedProductId);
                salesViewModel.SelectedCategoryId = (prod?.CategoryId == null) ? 0 : prod.CategoryId.Value;
                salesViewModel.Categories = await _categoryRepository.GetAllAsync();
            }


            return View("Index", salesViewModel);


        }
    }
}
