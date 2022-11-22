namespace database.Entities;

// 用于存储考勤记录
public class Dormitory
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid? DormBuildId { get; set; }
}