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
                        //HideMenu = true,
                        //HideBreadcrumb = true,
                        Title = "routes.dashboard.analysis",
                        //CurrentActiveMenu = "/dashboard",
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
                        //HideMenu = true,
                        //HideBreadcrumb = true,
                        Title = "routes.dashboard.workbench",
                        //CurrentActiveMenu = "/dashboard",
                        Icon = "bx:bx-home"
                    }
                }
            }
        },
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
        //new() { Name = "Dashboard", Meta = new Meta() { Title = "宿舍管理员管理" } },
        //new() { Meta = new Meta() { Title = "学生管理" } },
        //new() { Meta = new Meta() { Title = "宿舍楼管理" } },
        //new() { Meta = new Meta() { Title = "考勤打卡管理" } },
    };

}