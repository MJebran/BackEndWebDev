using Microsoft.EntityFrameworkCore;
using SnowCollegeHR.EmployeeManager.Data.Models;

namespace SnowCollegeHR.EmployeeManager.Data
{
    public class EmployeeManagerDBContext : DbContext
    {
        public EmployeeManagerDBContext(
            DbContextOptions<EmployeeManagerDBContext> options) : base(options)
        {
            //
        }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Math"},
                new Department { Id = 2, Name = "Physics" },
                new Department { Id = 3, Name = "IT" },
                new Department { Id = 4, Name = "Cleaning" },
                new Department { Id = 5, Name = "Finance" },
                new Department { Id = 6, Name = "Human Resources" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Mustafa", LastName = "Jebran", DepartmentId = 3, IsStudent = true},
                new Employee { Id = 2, FirstName = "Benson", LastName = "Bird", DepartmentId = 1, IsStudent = true },
                new Employee { Id = 3, FirstName = "Luris", LastName = "Solis", DepartmentId = 2, IsStudent = true },
                new Employee { Id = 4, FirstName = "Max", LastName = "Sorenson", DepartmentId = 6 });
        }
    }
}
