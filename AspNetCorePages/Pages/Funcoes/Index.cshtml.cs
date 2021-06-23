using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Funcoes
{
    public class IndexModel : PageModel
    {
        private readonly Domain.Data.EpiContext _context;

        public IndexModel(Domain.Data.EpiContext context)
        {
            _context = context;
        }

        public IList<Funcao> Funcao { get;set; }

        public async Task OnGetAsync()
        {
            Funcao = await _context.Funcaos
                .Include(f => f.Empresa).ToListAsync();
        }
    }
}
