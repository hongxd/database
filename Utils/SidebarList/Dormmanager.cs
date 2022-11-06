namespace database.Utils.SidebarList
{
    public class Dormmanager
    {
        public readonly List<Sidebar> SidebarList = new()
        {
            new Sidebar
            {
                Path = "/student",
                Name = "Student",
                Component = "/student/index",
                Meta = new Meta()
                    { Title = "学生管理" }
            },
            new Sidebar
            {
                Path = "/personalCenter",
                Name = "PersonalCenter",
                Component = "/personalCenter/index",
                Meta = new Meta()
                    { Title = "个人中心" }
            },
            new Sidebar { Meta = new Meta() { Title = "公告" } },
            new Sidebar { Meta = new Meta() { Title = "学生管理" } },
            new Sidebar { Meta = new Meta() { Title = "打卡记录管理" } },
            new Sidebar { Meta = new Meta() { Title = "考勤记录管理" } },
        };
    }
}
