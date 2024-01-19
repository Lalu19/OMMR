using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminApi.Models.User
{
    public class LogHistory
    {
		public long LogId { get; set; }
		public string LogCode { get; set; }
		public DateTime LogDate { get; set; }
		public int UserId { get; set; }
		public DateTime LogInTime { get; set; }
		public DateTime? LogOutTime { get; set; }
	}
}
