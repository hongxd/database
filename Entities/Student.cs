namespace database.Entities;

public class Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? StuNum { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public Guid DormBuildId { get; set; }
    public string? DormName { get; set; }
    public Gender? Sex { get; set; }
    public string? Tel { get; set; }
}