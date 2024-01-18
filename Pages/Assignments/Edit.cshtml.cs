using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Ghiriti_Edmond.Data;
using Project_Ghiriti_Edmond.Models;

namespace Project_Ghiriti_Edmond.Pages.Assignments
{
    public class EditModel : PageModel
    {
        private readonly Project_Ghiriti_Edmond.Data.HRContext _context;

        public EditModel(Project_Ghiriti_Edmond.Data.HRContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment =  await _context.Assignment.FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
            Assignment = assignment;
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
           ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(Assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(Assignment.AssignmentId))
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

        private bool AssignmentExists(int id)
        {
          return (_context.Assignment?.Any(e => e.AssignmentId == id)).GetValueOrDefault();
        }
    }
}
