using Microsoft.EntityFrameworkCore;

namespace studentAPI.DATA;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {           
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Address> Address { get; set; }
}
