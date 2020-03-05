using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class RegionesController : Controller
    {
        private readonly PokedexContext _context;

        public RegionesController(PokedexContext context)
        {
            _context = context;
        }

        // GET: Regiones
        public async Task<IActionResult> Index()
        {
            var pokedexContext = _context.Regiones.Include(r => r.IdColorNavigation);
            return View(await pokedexContext.ToListAsync());
        }

        // GET: Regiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones
                .Include(r => r.IdColorNavigation)
                .FirstOrDefaultAsync(m => m.IdRegion == id);
            if (regiones == null)
            {
                return NotFound();
            }

            return View(regiones);
        }

        // GET: Regiones/Create
        public IActionResult Create()
        {
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Codigo");
            return View();
        }

        // POST: Regiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegion,Nombre,IdColor")] Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Codigo", regiones.IdColor);
            return View(regiones);
        }

        // GET: Regiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return NotFound();
            }
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Codigo", regiones.IdColor);
            return View(regiones);
        }

        // POST: Regiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegion,Nombre,IdColor")] Regiones regiones)
        {
            if (id != regiones.IdRegion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionesExists(regiones.IdRegion))
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
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Codigo", regiones.IdColor);
            return View(regiones);
        }

        // GET: Regiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones
                .Include(r => r.IdColorNavigation)
                .FirstOrDefaultAsync(m => m.IdRegion == id);
            if (regiones == null)
            {
                return NotFound();
            }

            return View(regiones);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiones = await _context.Regiones.FindAsync(id);
            _context.Regiones.Remove(regiones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionesExists(int id)
        {
            return _context.Regiones.Any(e => e.IdRegion == id);
        }
    }
}
