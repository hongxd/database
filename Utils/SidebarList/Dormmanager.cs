namespace database.Utils.SidebarList;

public class Dormmanager
{
    public readonly List<Sidebar> SidebarList = new()
    {
        new Sidebar
        {
            Path = "/student",
            Name = "Student",
            Component = "/student/index",
            Meta = new Meta { Title = "学生管理" }
        },
        new Sidebar
        {
            Path = "/personalCenter",
            Name = "PersonalCenter",
            Component = "/personalCenter/index",
            Meta = new Meta { Title = "个人中心" }
        },
        new Sidebar
        {
            Path = "/announcement",
            Name = "Announcement",
            Component = "/announcement/index",
            Meta = new Meta { Title = "公告管理" }
        },
        new Sidebar
        {
            Path = "/announcement/add",
            Name = "AddAnnouncement",
            Component = "/announcement/Edit",
            Meta = new Meta
            {
                Title = "添加公告",
                CurrentActiveMenu = "/announcement",
                HideMenu = true,
                HideTab = true
            }
        },
        new Sidebar { Meta = new Meta { Title = "打卡记录管理" } },
        new Sidebar { Meta = new Meta { Title = "考勤记录管理" } }
    };
}