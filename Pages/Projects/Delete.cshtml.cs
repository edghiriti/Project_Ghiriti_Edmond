using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Ghiriti_Edmond.Data;
using Project_Ghiriti_Edmond.Models;

namespace Project_Ghiriti_Edmond.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly Project_Ghiriti_Edmond.Data.HRContext _context;

        public DeleteModel(Project_Ghiriti_Edmond.Data.HRContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Project Project { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FirstOrDefaultAsync(m => m.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }
            else 
            {
                Project = project;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }
            var project = await _context.Project.FindAsync(id);

            if (project != null)
            {
                Project = project;
                _context.Project.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
