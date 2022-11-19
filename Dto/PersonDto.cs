using database.Utils;

namespace database.Dto;

public class PersonDto
{
    public string? Username { get; set; }
    public string? Name { get; set; } // 真实姓名
    public Gender? Sex { get; set; }
    public string? Tel { get; set; }
    public string? DormBuildName { get; set; }
    public string? DormBuildDetail { get; set; }
    public string? Role { get; set; }
}