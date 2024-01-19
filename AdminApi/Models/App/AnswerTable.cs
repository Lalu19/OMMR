using System;

namespace AdminApi.Models.App
{
    public class AnswerTable
    {
        public int AnswerTableId { get; set; }
        public int QuestionTableId { get; set; }
        public int? OptionId { get; set; }
        public string Answers { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

