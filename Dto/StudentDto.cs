using database.Entities;

namespace database.Dto;

public class StudentPaginableDto : StudentDto, IPaginable
{
    public int? Page { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
}

public class StudentDto : Student
{
    public string? DormName { get; set; }
}