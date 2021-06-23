using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Domain.Model;

namespace AspNetCoreMVC.Controllers
{
    public class EpisController : Controller
    {
        private readonly EpiContext _context;

        public EpisController(EpiContext context)
        {
            _context = context;
        }

        // GET: Epis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Epis.ToListAsync());
        }

        // GET: Epis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epi = await _context.Epis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (epi == null)
            {
                return NotFound();
            }

            return View(epi);
        }

        // GET: Epis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Epis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomEpi,DatInclusao,DatValidade,NumCa,NumProcesso,NomFabricante,CnpjFabricante")] Epi epi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(epi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epi);
        }

        // GET: Epis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epi = await _context.Epis.FindAsync(id);
            if (epi == null)
            {
                return NotFound();
            }
            return View(epi);
        }

        // POST: Epis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomEpi,DatInclusao,DatValidade,NumCa,NumProcesso,NomFabricante,CnpjFabricante")] Epi epi)
        {
            if (id != epi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpiExists(epi.ID))
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
            return View(epi);
        }

        // GET: Epis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epi = await _context.Epis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (epi == null)
            {
                return NotFound();
            }

            return View(epi);
        }

        // POST: Epis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epi = await _context.Epis.FindAsync(id);
            _context.Epis.Remove(epi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpiExists(int id)
        {
            return _context.Epis.Any(e => e.ID == id);
        }
    }
}
