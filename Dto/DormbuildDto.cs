using database.Entities;

namespace database.Dto;

public class DormitoryPaginableDto : DormitoryDto, IPaginable
{
    public int? Page { get; set; }

    public int? PageSize { get; set; }
}

public class DormitoryDto : Dormitory
{
    // public string? ManagerName { get; set; }
}