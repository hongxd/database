namespace database.Entities
{
    // 用于存储打卡信息
    public class Punchclockrecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PunchClockId { get; set; }
        public DateTime? PunchClockDate { get; set; }
        public string? PunchClockTopic { get; set; }
        public string? PunchClockDetail { get; set; }
        public string? PunchClockPId { get; set; }
        public string? Name { get; set; }
        public string? DormName { get; set; }
        public string? Tel { get; set; }
        public string? StuNum { get; set; }
        public Guid DormBuildId { get; set; }
        public ushort? IsRecord { get; set; }
    }
}
