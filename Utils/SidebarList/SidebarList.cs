namespace database.Utils.SidebarList;

public static class SidebarList
{
    public static List<Sidebar> Admin() => new Admin().SidebarList;

    public static List<Sidebar> Dormmanager() => new Dormmanager().SidebarList;

    public static List<Sidebar> Student() => new Student().SidebarList;
}