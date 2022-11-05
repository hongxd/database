namespace database.Entities
{
    // 管理员表
    public class Admin
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public string Tel { get; set; }
    }
}
