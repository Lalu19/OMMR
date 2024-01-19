using System;

namespace AdminApi.Models.App
{
    public class HallPass
    {
        public int HallPassId { get; set; }
        public string AdsName { get; set; }
        public string HallPassImg { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
