namespace database.Dto
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; } = "https://q1.qlogo.cn/g?b=qq&nk=190848757&s=640";
        public string Desc { get; set; } = "manager";
        public string Password { get; set; }
        public string? Token { get; set; }
        public string HomePath { get; set; } = "/dashboard/analysis";
        public List<Roles> Roles { get; init; } = new();
    }

    public class Roles
    {
        public string? RoleName { get; set; }
        public string? Value { get; set; }
    }
}
