namespace database.Entities;

// 主要存储宿舍管理员信息
public class Dormmanager
{
    public Guid? Id { get; set; }
    public string? UserName { get; set; }
    protected internal string? Password { get; set; }

    public string? Name { get; set; }
    public int? Sex { get; set; }
    public string? Tel { get; set; }
}