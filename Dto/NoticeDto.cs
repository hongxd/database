using database.Entities;

namespace database.Dto;

public class NoticeDto : Notice
{
    public string NoticePerson { get; set; }
}