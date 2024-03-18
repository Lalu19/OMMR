using System.Collections.Generic;

namespace AdminApi.DTO.App
{
    public class OptionsTableDTO
    {
        public int QuestionId { get; set; }
        public string AdsName { get; set; }
        public string? Option { get; set; }
        public int CreatedBy { get; set; }
    }

    public class OptionsTableUpdateDTO
    {
        public int? OptionsId { get; set; }
        public string AdsName { get; set; }
        public int QuestionId { get; set; }
        public string? Option { get; set; }
        public int? UpdatedBy { get; set; }
    }

    public class OptionsTableMasterDTO
    {
        public List<OptionsTableDTO> OptionsTableDTOs { get; set; }
    }
}
