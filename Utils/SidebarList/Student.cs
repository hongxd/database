namespace database.Utils.SidebarList
{
    public class Student
    {
        public readonly List<Sidebar> SidebarList = new()
        {
            new Sidebar
            {
                Meta = new Meta() { Title = "公告" }
            },
            new Sidebar
            {
                Meta = new Meta() { Title = "查看考勤记录" }
            },
            new Sidebar { Meta = new Meta() { Title = "查看打卡记录" } }
        };
    }
}
