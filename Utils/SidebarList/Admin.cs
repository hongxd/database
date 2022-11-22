namespace database.Utils.SidebarList;

public class Admin
{
    public readonly List<Sidebar> SidebarList = new()
    {
        new Sidebar
        {
            Path = "/dashboard",
            Name = "Dashboard",
            Component = "layout",
            Redirect = "/dashboard/analysis",
            Meta = new Meta
            {
                Title = /*"公告管理"*/ "routes.dashboard.dashboard",
                Icon = "ion:grid-outline",
                Affix = true,
                HideTab = true,
                OrderNo = 10
            },
            Children = new List<Sidebar>
            {
                new()
                {
                    Path = "analysis",
                    Name = "Analysis",
                    Component = "/dashboard/analysis/index",
                    Meta = new Meta
                    {
                        Title = "routes.dashboard.analysis",
                        Icon = "bx:bx-home"
                    }
                },
                new()
                {
                    Path = "workbench",
                    Name = "Workbench",
                    Component = "/dashboard/workbench/index",
                    Meta = new Meta
                    {
                        Title = "routes.dashboard.workbench",
                        Icon = "bx:bx-home"
                    }
                }
            }
        },
        new Sidebar
        {
            Path = "/dorm",
            Name = "Dorm",
            Redirect = "/dormBuild",
            Meta = new Meta { Title = "宿舍管理" },
            Component = "layout",
            Children = new List<Sidebar>
            {
                new()
                {
                    Path = "/dormBuild",
                    Name = "DormBuild",
                    Component = "/dormBuild/index",
                    Meta = new Meta { Title = "楼宇管理" }
                },
                new()
                {
                    Path = "/dormitory",
                    Name = "Dormitory",
                    Component = "/dormitory/index",
                    Meta = new Meta { Title = "寝室管理" }
                }
            }
        },
        new Sidebar
        {
            Path = "/people",
            Name = "People",
            Redirect = "/dormManager",
            Meta = new Meta { Title = "人员管理" },
            Component = "layout",
            Children = new List<Sidebar>
            {
                new()
                {
                    Path = "/dormManager",
                    Name = "DormManager",
                    Component = "/dormManager/index",
                    Meta = new Meta { Title = "管理员管理" }
                },
                new()
                {
                    Path = "/student",
                    Name = "Student",
                    Component = "/student/index",
                    Meta = new Meta { Title = "学生管理" }
                }
            }
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
        new Sidebar
        {
            Path = "/repair",
            Name = "Repair",
            Component = "/repair/index",
            Meta = new Meta { Title = "报修管理" }
        },
        new Sidebar
        {
            Path = "/personalCenter",
            Name = "PersonalCenter",
            Component = "/personalCenter/index",
            Meta = new Meta { Title = "个人中心" }
        }
        //new() { Name = "Dashboard", Meta = new Meta() { Title = "宿舍管理员管理" } },
    };
}