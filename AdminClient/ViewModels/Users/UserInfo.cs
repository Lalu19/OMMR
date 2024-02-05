using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.ViewModels.Users
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
       // public string AdvertiseName { get; set; }
    }
}
