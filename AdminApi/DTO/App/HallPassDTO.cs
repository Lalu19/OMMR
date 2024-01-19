namespace AdminApi.DTO.App
{
    public class HallPassDTO
    {
        public string AdsName { get; set; }
        public string HallPassImg { get; set; }
        public int CreatedBy { get; set; }
    }
    public class HallPassUpdateDTO
    {
        public int HallPassId { get; set; }
        public string AdsName { get; set; }
        public string HallPassImg { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
