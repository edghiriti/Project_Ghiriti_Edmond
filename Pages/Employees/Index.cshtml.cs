using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Ghiriti_Edmond.Data;
using Project_Ghiriti_Edmond.Models;

namespace Project_Ghiriti_Edmond.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Project_Ghiriti_Edmond.Data.HRContext _context;

        public IndexModel(Project_Ghiriti_Edmond.Data.HRContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    if (_context.Employees != null)
        //    {
        //        Employee = await _context.Employees
        //        .Include(e => e.Department).ToListAsync();
        //    }
        //}

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var employees = from e in _context.Employees
                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId into department
                            from dept in department.DefaultIfEmpty()
                            select new Employee
                            {
                                EmployeeId = e.EmployeeId,
                                Name = e.Name,
                                Position = e.Position,
                                DepartmentId = e.DepartmentId,
                                Department = dept ?? new Department()
                            };

            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.Name.Contains(SearchString));
            }

            Employee = await employees.ToListAsync();
        }
    }
}
