using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Empresas
{
    public class EditModel : PageModel
    {
        private readonly Domain.Data.EpiContext _context;

        public EditModel(Domain.Data.EpiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empresa Empresa { get; set; }
        public List<SelectListItem> TipoIdentificadorOptions { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empresa = await _context.Empresas.FirstOrDefaultAsync(m => m.ID == id);

            TipoIdentificadorOptions = new List<SelectListItem>{ new SelectListItem { Value = "1", Text = "CNPJ" },new SelectListItem { Value = "2", Text = "CPF" }};

            if (Empresa == null)
            {
                return NotFound();
            }
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

            _context.Attach(Empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(Empresa.ID))
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

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.ID == id);
        }
    }
}
