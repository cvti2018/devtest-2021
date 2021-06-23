using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Epis
{
    public class DetailsModel : PageModel
    {
        private readonly Domain.Data.EpiContext _context;

        public DetailsModel(Domain.Data.EpiContext context)
        {
            _context = context;
        }

        public Epi Epi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Epi = await _context.Epis.FirstOrDefaultAsync(m => m.ID == id);

            if (Epi == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
