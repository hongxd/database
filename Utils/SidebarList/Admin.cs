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
            Path = "/dorm",
            Name = "Dorm",
            Redirect = "/dormBuild",
            Meta = new Meta
            {
                Title = "宿舍管理",
                Icon = "bx:bx-home"
            },
            Component = "layout",
            Children = new List<Sidebar>
            {
                new()
                {
                    Path = "/dormBuild",
                    Name = "DormBuild",
                    Component = "/dormBuild/index",
                    Meta = new Meta
                    {
                        Title = "楼宇管理"
                    }
                },
                new()
                {
                    Path = "/dormitory",
                    Name = "Dormitory",
                    Component = "/dormitory/index",
                    Meta = new Meta
                    {
                        Title = "寝室管理"
                    }
                }
            }
        },
        new Sidebar
        {
            Path = "/people",
            Name = "People",
            Redirect = "/dormManager",
            Meta = new Meta
            {
                Title = "人员管理",
                Icon = "ion:settings-outline"
            },
            Component = "layout",
            Children = new List<Sidebar>
            {
                new()
                {
                    Path = "/dormManager",
                    Name = "DormManager",
                    Component = "/dormManager/index",
                    Meta = new Meta
                    {
                        Title = "管理员管理"
                    }
                },
                new()
                {
                    Path = "/student",
                    Name = "Student",
                    Component = "/student/index",
                    Meta = new Meta
                    {
                        Title = "学生管理"
                    }
                }
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