namespace studentAPI.DATA;

public class InMemoryDataStore : IDataStore
{
    private List<Student> _students = new List<Student>();
    public Task<Student> AddStudent(Student student)
    {
        if (student.ID == 0)
        {
            student.ID = _students.Count + 1;
        }
        _students.Add(student);
        return Task.FromResult(student);
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        await Task.CompletedTask;
        return _students;
    }

    public Task<Student> GetStudent(int ID)
    {
        return Task.FromResult(_students.FirstOrDefault(r => r.ID == ID));

    }

    public Task RemoveStudent(int ID)
    {
        _students.RemoveAll(r => r.ID == ID);
        return Task.CompletedTask;
    }

    public async Task<Student> UpdateStudent(Student student)
    {
        await RemoveStudent(student.ID);
        return await AddStudent(student);
    }
}
