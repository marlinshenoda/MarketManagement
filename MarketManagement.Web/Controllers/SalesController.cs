using AutoMapper.Configuration;
using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using MarketManagement.Data.Repositories;
using MarketManagement.Web.Extensions;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<IdentityUser> _userManager;

        public SalesController(ApplicationDbContext context, IProductRepository service, UserManager<IdentityUser> userManager, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            _context = context;
            _service = service;
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
            _userManager = userManager;
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

        public async Task<IActionResult> Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                // Sell the product
                var product = await _service.GetByIdAsync(salesViewModel.SelectedProductId);
                if (product != null)
                {
                    if (product.Quantity < salesViewModel.QuantityToSell)
                        ModelState.AddModelError("", $"{product.Name} only has {product.Quantity} left. It is not enough.");
                    else
                    {
                        await _transactionRepository.Add(user.UserName,
                              salesViewModel.SelectedProductId,
                              product.Name,
                              product.Price.HasValue ? product.Price.Value : 0,
                              product.Quantity.HasValue ? product.Quantity.Value : 0,
                              salesViewModel.QuantityToSell);



                        product.Quantity -= salesViewModel.QuantityToSell;
                        await _service.UpdateAsync(salesViewModel.SelectedProductId, product);
                    }




                }
                else
                {
                    ModelState.AddModelError("", "Product not found.");
                }

            }
            var prod = await _service.GetByIdAsync(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (prod?.CategoryId == null) ? 0 : prod.CategoryId.Value;
            salesViewModel.Categories = await _categoryRepository.GetAllAsync();
            return View("Index", salesViewModel);


        }



    }
}