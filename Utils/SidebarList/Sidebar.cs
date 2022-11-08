namespace database.Utils.SidebarList;

public class Sidebar
{
    public string Path { get; set; } = "";
    public string Name { get; set; }
    public string Component { get; set; }
    public string? Redirect { get; set; }
    public Meta Meta { get; set; } = new();
    public List<Sidebar>? Children { get; set; }
}