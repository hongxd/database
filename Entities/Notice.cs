namespace database.Entities
{
    // 用于存储公告信息
    public class Notice
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
