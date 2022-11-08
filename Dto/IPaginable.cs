namespace database.Dto;

public interface IPaginable
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}