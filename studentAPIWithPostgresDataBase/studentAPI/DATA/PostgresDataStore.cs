using Microsoft.EntityFrameworkCore;

namespace studentAPI.DATA;

public class PostgresDataStore : IDataStore
{

    private readonly StudentContext context;
    public PostgresDataStore(StudentContext context)
    {
        this.context = context;
    }
    public async Task<Student> AddStudent(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return student;
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        return await context.Students.ToListAsync();
    }

    public Task<Student> GetStudent(int ID)
    {
        throw new NotImplementedException();
    }

    public Task RemoveStudent(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<Student> UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}
