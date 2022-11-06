namespace database.Utils.SidebarList
{
    public class Meta
    {
        public string Title { get; set; }
        public string? Icon { get; set; }
        public bool Affix { get; init; }
        public bool HideChildrenInMenu { get; init; }
        public bool HideMenu { get; init; }
        public bool HideBreadcrumb { get; init; }
        public string CurrentActiveMenu { get; set; }
        public int OrderNo { get; set; }
        public bool HideTab { get; set; }
    }
}
