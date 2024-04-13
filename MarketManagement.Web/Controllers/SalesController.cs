using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using MarketManagement.Data.Repositories;
using MarketManagement.Web.Extensions;
using MarketManagement.Web.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        public SalesController(ApplicationDbContext context, IProductRepository service, ICategoryRepository categoryRepository,ITransactionRepository  transactionRepository)
        {
            _context = context;
            _service = service;
            _categoryRepository = categoryRepository;
            _transactionRepository= transactionRepository;
        }
        public async Task<IActionResult> Index()
        {

            var salesViewModel = new SalesViewModel
            {
                Categories = await _categoryRepository.GetAllAsync()
            };
            return View(salesViewModel);
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
        public async Task<IActionResult> IsQuantityAvalable(int QuantityToSell, int SelectedProductId)
        {
            // Fetch the product from the database based on SelectedProductId
            var product = await _service.GetByIdAsync(SelectedProductId);

            // Check if the product exists
            if (product != null)
            {
                // Check if the quantity available in the database is greater than or equal to the quantity to sell
                if (product.Quantity >= QuantityToSell)
                {
                    // If quantity is available, return true
                    return Json(true);
                }
                else
                {
                    // If quantity is not available, return false
                    return Json(false);
                }
            }
            else
            {
                // If the product doesn't exist, return false or handle the case according to your requirements
                return Json(false);
            }
        }

        public async Task<IActionResult> Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product
                var product = await _service.GetByIdAsync(salesViewModel.SelectedProductId);
                if (product != null)
                {
                    _transactionRepository.Add("Cashier 1",
                        salesViewModel.SelectedProductId,
                        product.Name,
                        product.Price.HasValue ? product.Price.Value : 0,
                        product.Quantity.HasValue ? product.Quantity.Value : 0,
                        salesViewModel.QuantityToSell
                );
                    product.Quantity -= salesViewModel.QuantityToSell;
                    _service.UpdateAsync(salesViewModel.SelectedProductId, product);

                }
                var prod = await _service.GetByIdAsync(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (prod?.CategoryId == null) ? 0 : prod.CategoryId.Value;
            salesViewModel.Categories =await _categoryRepository.GetAllAsync();
            }
            
         

            return View("Index", salesViewModel);

        }   
      
    }


}