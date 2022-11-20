using database.Entities;

namespace database.Dto;

public class StudentPaginableDto : StudentDto, IPaginable
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}

public class StudentDto : Student
{
    public string? DormName { get; set; }
}