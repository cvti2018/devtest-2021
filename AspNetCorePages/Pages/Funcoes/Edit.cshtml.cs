﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Funcoes
{
    public class EditModel : PageModel
    {
        private readonly Domain.Data.EpiContext _context;

        public EditModel(Domain.Data.EpiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcao Funcao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcao = await _context.Funcaos
                .Include(f => f.Empresa).FirstOrDefaultAsync(m => m.ID == id);

            if (Funcao == null)
            {
                return NotFound();
            }
           ViewData["EmpresaId"] = new SelectList(_context.Empresas, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Funcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(Funcao.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcaos.Any(e => e.ID == id);
        }
    }
}
