using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.ViewModels.Menu
{
    public class MenuDisplay
    {
		public int MenuID { get; set; }
		public int ParentID { get; set; }
		public string MenuTitle { get; set; }
		public string URL { get; set; }
		public int IsSubMenu { get; set; }
		public int SortOrder { get; set; }
		public string IconClass { get; set; }
	}
}
