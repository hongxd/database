using database.Entities;

namespace database.Dto;

public class StudentResDto : Student
{
    public string? DormName { get; set; }
}