using database.Entities;

namespace database.Dto;

public class NoticePaginableDto : NoticeDto, IPaginable, ISortable
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? Field { get; set; }
    public string? Order { get; set; }
}

public class NoticeDto : Notice
{
    public string? NoticePerson { get; set; }
}

public readonly struct NoticeStruct
{
    public string? NoticePerson { get; }
    public Guid? Id { get; }
    public Guid? PId { get; }
    public DateTime? Date { get; }
    public string? Content { get; }
    public string? Title { get; }
}