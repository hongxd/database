namespace database.Entities
{
    // 存储宿舍楼信息
    public class Dormbuild
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Detail { get; set; }
    }
}
