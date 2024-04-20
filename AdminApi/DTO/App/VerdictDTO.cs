namespace AdminApi.DTO.App
{
    public class VerdictDTO
    {
        public string VerdictName { get; set; }
        public double VerdictValue { get; set; }
        public string ColorCode { get; set; }
        public int CreatedBy { get; set; }
    }
    public class UpdateVerdictDTO
    {
        public int VerdictId { get; set; }
        public string VerdictName { get; set; }
        public double VerdictValue { get; set; }
        public string ColorCode { get; set; }
        public int? UpdatedBy { get; set; }
    }

}
