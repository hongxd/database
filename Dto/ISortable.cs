namespace database.Dto;

public interface ISortable
{
    public string? Field { get; set; }
    public string? Order { get; set; }
}