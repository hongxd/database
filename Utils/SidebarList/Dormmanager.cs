namespace database.Utils.SidebarList;

public class Dormmanager
{
    public readonly List<Sidebar> SidebarList = new()
    {
        new Sidebar
        {
            Path = "/dashboard",
            Name = "Dashboard",
            Component = "layout",
            Redirect = "/dashboard/workbench",
            Meta = new Meta
            {
                Title = "dashboard",
                Icon = "ion:grid-outline",
                Affix = true,
                HideTab = true,
                OrderNo = 10
            },
            Children = new List<Sidebar>
            {
                new()
                {
                    Path = "workbench",
                    Name = "Workbench",
                    Component = "/dashboard/workbench/index",
                    Meta = new Meta
                    {
                        Title = "工作台"
                    }
                }
            }
        },
        new Sidebar
        {
            Path = "/dormitory",
            Name = "Dormitory",
            Component = "/dormitory/index",
            Meta = new Meta
            {
                Title = "寝室管理",
                Icon = "bx:bx-home"
            }
        },
        new Sidebar
        {
            Path = "/student",
            Name = "Student",
            Component = "/student/index",
            Meta = new Meta
            {
                Title = "学生管理",
                Icon = "ion:key-outline"
            }
        },
        new Sidebar
        {
            Path = "/announcement",
            Name = "Announcement",
            Component = "/announcement/index",
            Meta = new Meta
            {
                Title = "公告管理",
                Icon = "ion:bar-chart-outline"
            }
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
        new Sidebar
        {
            Path = "/repair",
            Name = "Repair",
            Component = "/repair/index",
            Meta = new Meta
            {
                Title = "报修管理",
                Icon = "uil:wrench"
            }
        },
        new Sidebar
        {
            Path = "/personalCenter",
            Name = "PersonalCenter",
            Component = "/personalCenter/index",
            Meta = new Meta
            {
                Title = "个人中心",
                Icon = "ion:layers-outline"
            }
        }
    };
}