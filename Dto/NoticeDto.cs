using database.Entities;

namespace database.Dto;

public class NoticePaginableDto : NoticeDto, IPaginable
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}

public class NoticeDto : Notice
{
    public string? NoticePerson { get; set; }
}