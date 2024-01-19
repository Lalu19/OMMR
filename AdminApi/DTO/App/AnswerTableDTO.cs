using System.Collections.Generic;

namespace AdminApi.DTO.App
{
    public class AnswerTableDTO
    {
        public int QuestionTableId { get; set; }
        public int? OptionId { get; set; }
        public string Answers { get; set; }
        public int CreatedBy { get; set; }
    }
    public class UpdateAnswerTableDTO
    {
        public int AnswerTableId { get; set; }
        public int QuestionTableId { get; set; }
        public int? OptionId { get; set; }
        public string Answers { get; set; }
        public int? UpdatedBy { get; set; }
    }
    public class AnswerTableMasterDTO
    {
        public List<AnswerTableDTO> AnswerTableDTOs { get; set; }
    }
}
