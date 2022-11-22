using database.Entities;

namespace database.Dto;

public class RepairDto : Repair
{
    public string? DormitoryName { get; set; }
}

public class RepairPaginableDto : RepairDto, IPaginable
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}