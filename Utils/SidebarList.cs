namespace database.Utils
{
    public class Sidebar
    {
        public string Title { get; set; }
        public List<Sidebar>? Children { get; set; }
    }
    public static class SidebarList
    {
        public static List<Sidebar> Admin()
        {
            return new List<Sidebar>()
            {
                new(){Title = "公告管理"},
                new(){Title = "宿舍管理员管理"},
                new(){Title = "学生管理"},
                new(){Title = "宿舍楼管理"},
                new(){Title = "考勤打卡管理"},
            };
        }
        public static List<Sidebar> Dormmanager()
        {
            return new List<Sidebar>()
            {
                new() { Title = "公告" },
                new() { Title = "学生管理" },
                new() { Title = "打卡记录管理" },
                new() { Title = "考勤记录管理" },
            };
        }
        public static List<Sidebar> Student()
        {
            return new List<Sidebar>()
            {
                new(){Title = "公告"},
                new(){Title = "查看考勤记录"},
                new(){Title = "查看打卡记录"}
            };
        }
    }
}
