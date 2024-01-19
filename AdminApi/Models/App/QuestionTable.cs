using System;


namespace AdminApi.Models.App
{
    public class QuestionTable
    {        
        public int QuestionTableId { get; set; }
        public string Questions { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
