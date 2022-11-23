namespace database.Utils;

public class MapSortOrder
{
    public static string Map(string? order)
    {
        return order switch
        {
            "ascend" => "asc",
            _ => "desc"
        };
    }
}