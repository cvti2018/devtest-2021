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
    public class FuncoesController : Controller
    {
        private readonly EpiContext _context;

        public FuncoesController(EpiContext context)
        {
            _context = context;
        }

        // GET: Funcaos
        public async Task<IActionResult> Index()
        {
            var epiContext = _context.Funcaos.Include(f => f.Empresa);
            return View(await epiContext.ToListAsync());
        }

        // GET: Funcaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcaos
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // GET: Funcaos/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "ID", "ID");
            return View();
        }

        // POST: Funcaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomeFuncao,EmpresaId")] Funcao funcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "ID", "ID", funcao.EmpresaId);
            return View(funcao);
        }

        // GET: Funcaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcaos.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "ID", "ID", funcao.EmpresaId);
            return View(funcao);
        }

        // POST: Funcaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomeFuncao,EmpresaId")] Funcao funcao)
        {
            if (id != funcao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncaoExists(funcao.ID))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "ID", "ID", funcao.EmpresaId);
            return View(funcao);
        }

        // GET: Funcaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcaos
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // POST: Funcaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcao = await _context.Funcaos.FindAsync(id);
            _context.Funcaos.Remove(funcao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcaos.Any(e => e.ID == id);
        }
    }
}
