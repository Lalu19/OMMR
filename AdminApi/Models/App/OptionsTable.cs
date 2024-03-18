using System;

namespace AdminApi.Models.App
{
    public class Options
    {
        public int? OptionsId { get; set; }
        public string AdsName { get; set; }
        public int QuestionId { get; set; }
        public string? Option { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
