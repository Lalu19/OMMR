using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Models.Menu
{
	public class MenuGroup
    {	
		public int MenuGroupID { get; set; }
		[Required]
		[StringLength(100)]
		public string MenuGroupName { get; set; }
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
