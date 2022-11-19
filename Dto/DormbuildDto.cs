using database.Entities;

namespace database.Dto;

public class DormbuildDto : Dormbuild, IPaginable
{
    public string? ManagerName { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}