using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Ghiriti_Edmond.Data;
using Project_Ghiriti_Edmond.Models;

namespace Project_Ghiriti_Edmond.Pages.Employees
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
            Employee = new Employee();
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", Employee?.DepartmentId);
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
