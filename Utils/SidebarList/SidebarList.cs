namespace database.Utils.SidebarList
{
    public static class SidebarList
    {
        public static List<Sidebar> Admin()
        {
            return new Admin().SidebarList;
        }
        public static List<Sidebar> Dormmanager()
        {
            return new Dormmanager().SidebarList;
        }
        public static List<Sidebar> Student()
        {
            return new Student().SidebarList;
        }
    }
}
