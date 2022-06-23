﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginDemoDay64.Data;
using LoginDemoDay64.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoginDemoDay64.Controllers
{
    public class NationalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
              return _context.Nationalities != null ? 
                          View(await _context.Nationalities.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nationalities'  is null.");
        }

        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nationalities == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // GET: Nationalities/Create

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Create([Bind("Id,Text,Continent,CountryPopulation")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Edit/5

        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nationalities == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "SuperAdmin,Admin,")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,Continent,CountryPopulation")] Nationality nationality)
        {
            if (id != nationality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationality.Id))
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
            return View(nationality);
        }

        // GET: Nationalities/Delete/5

        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nationalities == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nationalities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nationalities'  is null.");
            }
            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality != null)
            {
                _context.Nationalities.Remove(nationality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(int id)
        {
          return (_context.Nationalities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
