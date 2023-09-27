using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace studentAPI.DATA;

public class JsonDataStore : IDataStore
{
    List<Student> students;
    string studentPath = "students.json";
    public JsonDataStore()
    {
        students = new();
        if (File.Exists(studentPath))
        {
            var json = File.ReadAllText(studentPath);
            students = JsonSerializer.Deserialize<List<Student>>(json);
        }
    }

    public async Task<Student> AddStudent(Student student)
    {
        if (students.Count == 0)
        {
            student.ID = 1;
        }
        else
        {
            student.ID = students.Max(r => r.ID) + 1;
        }
        students.Add(student);
        await saveStudents();
        return student;
    }

    private async Task saveStudents()
    {
        var json = JsonSerializer.Serialize(students);
        await File.WriteAllTextAsync(studentPath, json);
    }
    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        await Task.CompletedTask;
        return students;
    }

    public Task<Student> GetStudent(int ID)
    {
        return Task.FromResult(students.FirstOrDefault(r => r.ID == ID));
    }

    public Task RemoveStudent(int ID)
    {
        students.RemoveAll(r => r.ID == ID);
        return Task.CompletedTask;
    }

    public async Task<Student> UpdateStudent(Student student)
    {
        var studentToEdit = students.FirstOrDefault(r => r.ID == student.ID);
        studentToEdit.PhoneNumer = student.PhoneNumer;
        studentToEdit.Address = student.Address;
        studentToEdit.DOB = student.DOB;
        studentToEdit.Name = student.Name;

        await saveStudents();
        return student;
    }
}
