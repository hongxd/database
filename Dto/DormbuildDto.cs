using database.Entities;

namespace database.Dto;

public class DormbuildPaginableDto : DormbuildDto, IPaginable
{
    public int? Page { get; set; }

    public int? PageSize { get; set; }
}

public class DormbuildDto : Dormbuild
{
    public string? ManagerName { get; set; }
}