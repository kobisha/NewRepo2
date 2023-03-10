using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using marlin.Data;
using marlin.Models;

namespace marlin.Controllers
{
    public class CataloguesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CataloguesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalogues
        public async Task<IActionResult> Index()
        {
              return View(await _context.Catalogue.ToListAsync());
        }

        // GET: Catalogues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalogue == null)
            {
                return NotFound();
            }

            var catalogue = await _context.Catalogue
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catalogue == null)
            {
                return NotFound();
            }

            return View(catalogue);
        }

        // GET: Catalogues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccountID,ProductID,SourceCode,Name,Description,Barcode,Unit,Status,LastChangeDate")] Catalogue catalogue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogue);
        }

        // GET: Catalogues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalogue == null)
            {
                return NotFound();
            }

            var catalogue = await _context.Catalogue.FindAsync(id);
            if (catalogue == null)
            {
                return NotFound();
            }
            return View(catalogue);
        }

        // POST: Catalogues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AccountID,ProductID,SourceCode,Name,Description,Barcode,Unit,Status,LastChangeDate")] Catalogue catalogue)
        {
            if (id != catalogue.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogueExists(catalogue.ID))
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
            return View(catalogue);
        }

        // GET: Catalogues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalogue == null)
            {
                return NotFound();
            }

            var catalogue = await _context.Catalogue
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catalogue == null)
            {
                return NotFound();
            }

            return View(catalogue);
        }

        // POST: Catalogues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalogue == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Catalogue'  is null.");
            }
            var catalogue = await _context.Catalogue.FindAsync(id);
            if (catalogue != null)
            {
                _context.Catalogue.Remove(catalogue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogueExists(int id)
        {
          return _context.Catalogue.Any(e => e.ID == id);
        }
    }
}
