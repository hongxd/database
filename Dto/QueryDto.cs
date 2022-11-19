namespace database.Dto;

public class QueryDto<T>
{
    public int Total { get; set; }
    public T[]? List { get; set; }
}

public class QueryResultDto<T>
{
    public QueryDto<T>? Result { get; set; }
}