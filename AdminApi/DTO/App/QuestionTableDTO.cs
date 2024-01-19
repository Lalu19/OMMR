namespace AdminApi.DTO.App
{
    public class QuestionTableDTO
    {
        public string Questions { get; set; }
        public int CreatedBy { get; set; }
    }
    public class UpdateQuestionTableDTO
    {
        public int QuestionTableId { get; set; }
        public string Questions { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
