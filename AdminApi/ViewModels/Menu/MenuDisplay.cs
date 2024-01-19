    namespace AdminApi.ViewModels.Menu
    {
        public class MenuDisplay
        {
            public int MenuID { get; set; }
            public int ParentID { get; set; }
            public string MenuTitle { get; set; }
            public string URL { get; set; }
            public int IsSubMenu { get; set; }
            public long SortOrder { get; set; }
            public string IconClass { get; set; }
            public int MenuGroupId { get; set; }
        }
    }
