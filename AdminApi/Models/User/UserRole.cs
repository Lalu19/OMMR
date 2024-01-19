using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AdminApi.Models.User
{
	public class UserRole
    {
		public int UserRoleId { get; set; }
		[Required]
		[StringLength(100)]
		public string RoleName { get; set; }
		[StringLength(500)]
		public string RoleDesc { get; set; }
		public int? MenuGroupId { get; set; }
		[Required]
		public bool IsActive { get; set; }
		[Required]	
		public int AddedBy { get; set; }
		[Required]
		public DateTime DateAdded { get; set; }
		[DefaultValue(false)]
		public bool IsMigrationData { get; set; }
		public DateTime? LastUpdatedDate { get; set; }
		public int? LastUpdatedBy { get; set; }
	}
}
