using System;

namespace AdminApi.ViewModels.User
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
        public DateTime? DateOfBirth { get; set; }
        public int? LastUpdatedBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public int HospitalMasterid { get; set; }
        //public string HospitalName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string AdvertiseName { get; set; }
        public double TotalVerificationCount { get; set; }

        //public int? CityId { get; set; }
        //public string? CityName { get; set; }
        //public int? AreaId { get; set; }
        //public string? AreaName { get; set; }

        public string Address { get; set; }
        public bool DeleteRequested { get; set; }
        public string SuperAdminDeletionResponse { get; set; }
    }
}