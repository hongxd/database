namespace database.Entities;

// 用于存储打卡发布记录
public class Punchclock
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string? Topic { get; set; }
    public string? Detail { get; set; }
    public DateTime? Date { get; set; }
    public Guid PId { get; set; }
}