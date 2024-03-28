using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketManagement.Core.Entities;
using MarketManagement.Data.Data;
using MarketManagement.Core.Interfaces;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Data.Repositories;

namespace MarketManagement.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _service;
        private ICategoryRepository _categoryRepository;

        public ProductsController(ApplicationDbContext context,IProductRepository service ,ICategoryRepository  categoryRepository)
        {
            _context = context;
            _service = service;
            _categoryRepository=categoryRepository;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Category);
            return View(allProducts);
         
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult>Create()
        {
            ViewBag.Action = "create";

            var product = new ProductViewModel
            {
                Categories = await _categoryRepository.GetAllAsync()
            };

            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel createproduct)
        {
             ViewBag.Action = "create";

            if (ModelState.IsValid)
            {
                await _service.AddAsync(createproduct.Product);
                return RedirectToAction(nameof(Index));
            
            }

            return View(createproduct);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "edit";

          
            var product = new ProductViewModel
            {
                Product = await _service.GetByIdAsync(id),
                
                Categories= await _categoryRepository.GetAllAsync()

            };
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel editproduct)
        {
            if (id != editproduct.Product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(id, editproduct.Product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(editproduct.Product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "deit";

            return View(editproduct);
         

        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
       
        }

     

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
