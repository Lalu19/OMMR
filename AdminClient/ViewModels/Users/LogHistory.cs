using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.ViewModels.Users
{
    public class LogHistory
    {		
		public string LogCode { get; set; }		
		public DateTime LogDate { get; set; }		
		public int UserId { get; set; }		
		public DateTime LogInTime { get; set; }
	}
}
