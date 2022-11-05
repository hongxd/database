namespace database.Entities
{
    // 用于存储考勤记录
    public class Record
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudentNumber { get; set; }
        public Guid DormBuildId { get; set; }
        public string DormName { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
    }
}
