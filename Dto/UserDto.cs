namespace database.Dto;

public class UserDto
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public Role RoleId { get; set; }
}

public class User
{
    public string Username { get; set; } = "";
    public string Role { get; set; } = "";
    public Guid? Id { get; set; }
}