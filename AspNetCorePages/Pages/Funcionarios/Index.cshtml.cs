using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Domain.Model;

namespace AspNetCorePages.Pages.Funcionarios
{
    public class IndexModel : PageModel
    {
        private readonly Domain.Data.EpiContext _context;

        public IndexModel(Domain.Data.EpiContext context)
        {
            _context = context;
        }

        public IList<Funcionario> Funcionario { get;set; }

        public async Task OnGetAsync()
        {
            Funcionario = await _context.Funcionarios
                .Include(f => f.Funcao).ToListAsync();
        }
    }
}
