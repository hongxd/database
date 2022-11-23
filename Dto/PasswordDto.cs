namespace database.Dto;

public class PasswordDto
{
    public string OldPassword { get; set; }
    public string newPassword { get; set; }
    public string Password { get; set; }
}

public class UserPasswordDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}