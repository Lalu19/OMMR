using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AdminApi.Models.Menu
{
    public class AppMenu
    {
		public int MenuID { get; set; }
		[Required]
		public int ParentID { get; set; }
		[Required]
		[StringLength(100)]
		public string MenuTitle { get; set; }
		[StringLength(500)]
		public string URL { get; set; }
		[Required]
		public int IsSubMenu { get; set; }
		[Required]
		public int SortOrder { get; set; }
		public string IconClass { get; set; }
		[Required]
		public bool IsActive { get; set; }
		[Required]
		public DateTime DateAdded { get; set; }
		[Required]
		public int AddedBy { get; set; }
		[DefaultValue(false)]
		public bool IsMigrationData { get; set; }
		public DateTime? LastUpdatedDate { get; set; }
		public int? LastUpdatedBy { get; set; }
	}
}
