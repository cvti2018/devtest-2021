using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Epis
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
            return Page();
        }

        [BindProperty]
        public Epi Epi { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Epis.Add(Epi);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
