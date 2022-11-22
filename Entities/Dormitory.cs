namespace database.Entities;

public class Dormitory
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid? DormBuildId { get; set; }
}