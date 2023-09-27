using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using studentAPI.DATA;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;
    private readonly IDataStore dataStore;

    public StudentController(ILogger<StudentController> logger, IDataStore dataStore)
    {
        this.dataStore = dataStore;
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IEnumerable<Student>> Get()
    { 
        return await dataStore.GetAllStudents();
    }

    [HttpGet("{id}")]
    public async Task<Student> Get(int id)
    {
        return await dataStore.GetStudent(id);
    }

    [HttpPost]
    public async Task<Student> Post([FromBody] Student student)
    { 
        await dataStore.AddStudent(student);
        return student;
    }

    [HttpDelete("{id}")]
    public void Delete(int id) 
    { 
       dataStore.RemoveStudent(id);
    }

    [HttpPatch]
    public async void Update(Student student)
    {
        await dataStore.GetStudent(student.ID);
        await dataStore.UpdateStudent(student);
    }
}

