using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjemploMvcConversor.Models;

namespace EjemploMvcConversor.Controllers
{
    public class paisesController : Controller
    {
        private readonly ContextoConversor _context;

        public paisesController(ContextoConversor context)
        {
            _context = context;
        }

        // GET: paises
        public async Task<IActionResult> Index()
        {
              return _context.Paises != null ? 
                          View(await _context.Paises.ToListAsync()) :
                          Problem("Entity set 'ContextoConversor.Paises'  is null.");
        }

        // GET: paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paises = await _context.Paises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paises == null)
            {
                return NotFound();
            }

            return View(paises);
        }

        // GET: paises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: paises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] paises paises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paises);
        }

        // GET: paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paises = await _context.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }
            return View(paises);
        }

        // POST: paises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] paises paises)
        {
            if (id != paises.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!paisesExists(paises.Id))
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
            return View(paises);
        }

        // GET: paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paises = await _context.Paises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paises == null)
            {
                return NotFound();
            }

            return View(paises);
        }

        // POST: paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paises == null)
            {
                return Problem("Entity set 'ContextoConversor.Paises'  is null.");
            }
            var paises = await _context.Paises.FindAsync(id);
            if (paises != null)
            {
                _context.Paises.Remove(paises);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool paisesExists(int id)
        {
          return (_context.Paises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
