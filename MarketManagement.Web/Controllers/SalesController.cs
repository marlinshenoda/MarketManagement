﻿using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using MarketManagement.Data.Repositories;
using MarketManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
    }
}
