namespace database.Entities;

// 存储宿舍楼信息
public class Dormbuild
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Detail { get; set; }
    public Guid? Dormmanager { get; set; }
}