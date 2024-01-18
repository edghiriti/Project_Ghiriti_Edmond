using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Ghiriti_Edmond.Data;
using Project_Ghiriti_Edmond.Models;

namespace Project_Ghiriti_Edmond.Pages.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly Project_Ghiriti_Edmond.Data.HRContext _context;

        public CreateModel(Project_Ghiriti_Edmond.Data.HRContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
        ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return Page();
        }

        [BindProperty]
        public Assignment Assignment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Assignment == null || Assignment == null)
          //  {
          //      return Page();
          //  }

            _context.Assignment.Add(Assignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
