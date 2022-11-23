using database.Entities;

namespace database.Dto;

public class StudentPaginableDto : StudentDto, IPaginable
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}

public class StudentDto : Student
{
    /// <summary>
    ///     宿舍楼宇名字
    /// </summary>
    public string? DormName { get; set; }

    /// <summary>
    ///     寝室号
    /// </summary>
    public string? DormitoryName { get; set; }

    public Guid? DormBuildId { get; set; }
}