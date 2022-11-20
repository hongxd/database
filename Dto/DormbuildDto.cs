using database.Entities;

namespace database.Dto;

public class DormbuildPaginableDto : DormbuildDto, IPaginable
{
    public int? Page { get; set; } = 1;

    public int? PageSize { get; set; } = 10;
}

public class DormbuildDto : Dormbuild
{
    public string? ManagerName { get; set; }
}
