using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Empresas
{
    public class CreateModel : PageModel
    {
        private readonly Domain.Data.EpiContext _context;

        public CreateModel(Domain.Data.EpiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            TipoIdentificadorOptions = new List<SelectListItem> { new SelectListItem { Value = "1", Text = "CNPJ" }, new SelectListItem { Value = "2", Text = "CPF" } };
            return Page();
        }

        [BindProperty]
        public Empresa Empresa { get; set; }
        public List<SelectListItem> TipoIdentificadorOptions { get; private set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Empresas.Add(Empresa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
