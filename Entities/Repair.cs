namespace database.Entities;

public class Repair
{
    public Guid? Id { get; init; }
    public string? Thing { get; set; }
    public string? Detail { get; set; }
    public DateTime? ReportTime { get; set; }
    public int? Status { get; set; }
}