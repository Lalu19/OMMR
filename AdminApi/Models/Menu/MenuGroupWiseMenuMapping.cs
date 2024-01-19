using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AdminApi.Models.Menu
{
	public class MenuGroupWiseMenuMapping
    {
		public int MenuGroupWiseMenuMappingId { get; set; }
		[Required]
		public int MenuGroupId { get; set; }
		[Required]
		public int MenuId { get; set; }
		[Required]
		public bool IsActive { get; set; }
		[DefaultValue(false)]
		public bool IsMigrationData { get; set; }
		[Required]
		public DateTime DateAdded { get; set; }
		[Required]
		public int AddedBy { get; set; }
	}
}
