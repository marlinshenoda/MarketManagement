﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketManagement.Core.Entities;
using MarketManagement.Data.Data;
using MarketManagement.Data.Repositories;
using MarketManagement.Core.Interfaces;
using System.Numerics;

namespace MarketManagement.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _service;

        public CategoriesController(ApplicationDbContext context,ICategoryRepository service)
        {
            _context = context;
            _service = service; 
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

       // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Details = await _service.GetByIdAsync(id);
            if (Details == null)
            {
                return NotFound();
            }

            return View(Details);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewBag.Action = "Create";

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.Action = "Create";

            if (ModelState.IsValid)
            {
             await _service.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

      //  GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "edit";

            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Category category)
        {
            
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(id, category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

       // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                _context.Category.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
