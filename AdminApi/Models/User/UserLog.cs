using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminApi.Models.User
{
    public class UserLog
    {	
		public int Count { get; set; }
		public string Date { get; set; }
		public int Month { get; set; }	
		public int Year { get; set; }
		public string RoleName { get; set; }
	}
}