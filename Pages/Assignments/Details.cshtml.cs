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
    public class DetailsModel : PageModel
    {
        private readonly Project_Ghiriti_Edmond.Data.HRContext _context;

        public DetailsModel(Project_Ghiriti_Edmond.Data.HRContext context)
        {
            _context = context;
        }

      public Assignment Assignment { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Project)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
            else 
            {
                Assignment = assignment;
            }
            return Page();
        }
    }
}
