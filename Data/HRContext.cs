using Microsoft.EntityFrameworkCore;
using Project_Ghiriti_Edmond.Models;
namespace Project_Ghiriti_Edmond.Data
{
    using Microsoft.EntityFrameworkCore;
    using Project_Ghiriti_Edmond.Models;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and any additional configuration
        }

        public DbSet<Project_Ghiriti_Edmond.Models.Project> Project { get; set; } = default!;

        public DbSet<Project_Ghiriti_Edmond.Models.Assignment> Assignment { get; set; } = default!;
    }

}
