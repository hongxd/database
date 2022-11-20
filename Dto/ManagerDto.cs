using database.Entities;

namespace database.Dto;

public class ManagerPaginableDto : ManagerDto, IPaginable
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}

public class ManagerDto : Dormmanager
{
    public string? DormBuildName { get; set; }
}