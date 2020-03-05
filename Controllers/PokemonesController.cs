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
    public class PokemonesController : Controller
    {
        private readonly PokedexContext _context;

        public PokemonesController( PokedexContext context)
        {
            _context = context;
        }

        // GET: Pokemones
        public async Task<IActionResult> Index()
        {
            var pokedexContext = _context.Pokemones.Include(p => p.IdRegionNavigation);
            return View(await pokedexContext.ToListAsync());
        }

        // GET: Pokemones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemones = await _context.Pokemones
                .Include(p => p.IdRegionNavigation)
                .FirstOrDefaultAsync(m => m.IdPokemon == id);
            if (pokemones == null)
            {
                return NotFound();
            }

            return View(pokemones);
        }

        // GET: Pokemones/Create
        public IActionResult Create()
        {
            ViewData["IdRegion"] = new SelectList(_context.Regiones, "IdRegion", "Nombre");
            return View();
        }

        // POST: Pokemones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPokemon,Nombre,IdRegion")] Pokemones pokemones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRegion"] = new SelectList(_context.Regiones, "IdRegion", "Nombre", pokemones.IdRegion);
            return View(pokemones);
        }

        // GET: Pokemones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemones = await _context.Pokemones.FindAsync(id);
            if (pokemones == null)
            {
                return NotFound();
            }
            ViewData["IdRegion"] = new SelectList(_context.Regiones, "IdRegion", "Nombre", pokemones.IdRegion);
            return View(pokemones);
        }

        // POST: Pokemones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPokemon,Nombre,IdRegion")] Pokemones pokemones)
        {
            if (id != pokemones.IdPokemon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonesExists(pokemones.IdPokemon))
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
            ViewData["IdRegion"] = new SelectList(_context.Regiones, "IdRegion", "Nombre", pokemones.IdRegion);
            return View(pokemones);
        }

        // GET: Pokemones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemones = await _context.Pokemones
                .Include(p => p.IdRegionNavigation)
                .FirstOrDefaultAsync(m => m.IdPokemon == id);
            if (pokemones == null)
            {
                return NotFound();
            }

            return View(pokemones);
        }

        // POST: Pokemones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemones = await _context.Pokemones.FindAsync(id);
            _context.Pokemones.Remove(pokemones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonesExists(int id)
        {
            return _context.Pokemones.Any(e => e.IdPokemon == id);
        }
    }
}
