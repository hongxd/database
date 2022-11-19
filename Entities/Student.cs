using database.Utils;

namespace database.Entities;

public class Student
{
    public Guid? Id { get; set; }
    public string? StuNum { get; set; }
    protected internal string? Password { get; set; }
    public string? Name { get; set; }
    public Guid? DormBuildId { get; set; }
    public string? DormName { get; set; }
    public Gender? Sex { get; set; }
    public string? Tel { get; set; }
}