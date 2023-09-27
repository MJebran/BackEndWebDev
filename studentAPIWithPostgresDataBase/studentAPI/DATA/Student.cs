namespace studentAPI.DATA;

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string DOB { get; set; }
    public int PhoneNumer { get; set; }
    public List<Address> Address { get; set; }

}
