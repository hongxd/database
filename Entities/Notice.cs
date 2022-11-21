namespace database.Entities;

// 用于存储公告信息
public class NoticeDb : Notice
{
    // 数据库模型不能被继承
}

public class Notice
{
    // 这是一个用于被继承的父类
    public Guid? Id { get; set; }
    public Guid? PId { get; set; }
    public DateTime? Date { get; set; }
    public string? Content { get; set; }
    public string? Title { get; set; }
}