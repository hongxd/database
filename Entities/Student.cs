namespace database.Entities;

public class Student
{
    public Guid? Id { get; set; }
    public string? StuNum { get; set; }
    protected internal string? Password { get; set; }
    public string? Name { get; set; }
    public Guid? DormitoryId { get; set; }
    public int? Sex { get; set; }
    public string? Tel { get; set; }
}