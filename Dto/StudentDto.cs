using database.Entities;

namespace database.Dto;

public class StudentDto : Student, IPaginable
{
    private int _page = 1;
    private int _pageSize = 10;
    public string? DormName { get; set; }

    int IPaginable.Page
    {
        get => _page;
        set => _page = value;
    }

    int IPaginable.PageSize
    {
        get => _pageSize;
        set => _pageSize = value;
    }
}