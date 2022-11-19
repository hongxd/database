using database.Entities;

namespace database.Dto;

public class ManagerDto : Dormmanager, IPaginable
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}