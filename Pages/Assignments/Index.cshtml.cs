using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Ghiriti_Edmond.Data;
using Project_Ghiriti_Edmond.Models;

namespace Project_Ghiriti_Edmond.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly Project_Ghiriti_Edmond.Data.HRContext _context;

        public IndexModel(Project_Ghiriti_Edmond.Data.HRContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Assignment != null)
            {
                Assignment = await _context.Assignment
                .Include(a => a.Employee)
                .Include(a => a.Project).ToListAsync();
            }
        }
    }
}
