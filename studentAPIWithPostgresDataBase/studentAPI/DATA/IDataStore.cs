using studentAPI;
namespace studentAPI.DATA;

public interface IDataStore
{
    Task<Student> GetStudent(int ID);
    Task<IEnumerable<Student>> GetAllStudents();
    Task<Student> AddStudent(Student student);
    Task<Student> UpdateStudent(Student student);
    Task RemoveStudent(int ID);


}
