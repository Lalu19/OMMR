using Microsoft.AspNetCore.Http;

namespace AdminClient.DTO
{
    public class AgentFeedbackFormDTO
    {
        public int StateId { get; set; }
        public int AgentId { get; set; }
        public int AdScreenId { get; set; }
        public int? AdsVariantStatusOk { get; set; }
        public int? AdsVariantStatusNotOk { get; set; }
        public string AdsVariantStatusRemark { get; set; }
        public int? AdsDurationStatusOk { get; set; }
        public int? AdsDurationStatusNotOk { get; set; }
        public string AdsDurationStatusRemark { get; set; }
        public int? AdsPlayTimeStatusOk { get; set; }
        public int? AdsPlayTimeStatusNotOk { get; set; }
        public string AdsPlayTimeStatusRemark { get; set; }
        public int? AdsSequenceStatusOk { get; set; }
        public int? AdsSequenceStatusNotOk { get; set; }
        public string AdsSequenceStatusRemark { get; set; }
        public string Occupancy { get; set; }
        public int? LanguageStatusOk { get; set; }
        public int? LanguageStatusNotOk { get; set; }
        public string LanguageStatusRemark { get; set; }
        public int? TheaterInspectionStatusforMale { get; set; }
        public int? TheaterInspectionStatusforFemale { get; set; }
        public string TheaterInspectionforMale { get; set; }
        public string TheaterInspectionforFemale { get; set; }
        public string? AgentSelfie { get; set; }
        public int CreatedBy { get; set; }
        public IFormFile file { get; set; }
    }
    public class AgentFeedbackFormViewModel
    {
        public int AdScreenFeedbackFormId { get; set; }
        public int AdScreenId { get; set; }
        public int StateId { get; set; }
        public int AgentId { get; set; }
        public int? AdsVariantStatusOk { get; set; }
        public int? AdsVariantStatusNotOk { get; set; }
        public string AdsVariantStatusRemark { get; set; }
        public int? AdsDurationStatusOk { get; set; }
        public int? AdsDurationStatusNotOk { get; set; }
        public string AdsDurationStatusRemark { get; set; }
        public int? AdsPlayTimeStatusOk { get; set; }
        public int? AdsPlayTimeStatusNotOk { get; set; }
        public string AdsPlayTimeStatusRemark { get; set; }
        public int? AdsSequenceStatusOk { get; set; }
        public int? AdsSequenceStatusNotOk { get; set; }
        public string AdsSequenceStatusRemark { get; set; }
        public string Occupancy { get; set; }
        public int? LanguageStatusOk { get; set; }
        public int? LanguageStatusNotOk { get; set; }
        public string LanguageStatusRemark { get; set; }
        public int? TheaterInspectionStatusforMale { get; set; }
        public int? TheaterInspectionStatusforFemale { get; set; }
        public string TheaterInspectionforMale { get; set; }
        public string TheaterInspectionforFemale { get; set; }
        public string? AgentSelfie { get; set; }
        public int CreatedBy { get; set; }
    }
    public class AgentFeedbackFormNewDTO
    {
        public int StateId { get; set; }
        public int AgentId { get; set; }
        public int AdScreenId { get; set; }
        public int? AdsVariantStatusOk { get; set; }
        public int? AdsVariantStatusNotOk { get; set; }
        public string AdsVariantStatusRemark { get; set; }
        public int? AdsDurationStatusOk { get; set; }
        public int? AdsDurationStatusNotOk { get; set; }
        public string AdsDurationStatusRemark { get; set; }
        public int? AdsPlayTimeStatusOk { get; set; }
        public int? AdsPlayTimeStatusNotOk { get; set; }
        public string AdsPlayTimeStatusRemark { get; set; }
        public int? AdsSequenceStatusOk { get; set; }
        public int? AdsSequenceStatusNotOk { get; set; }
        public string AdsSequenceStatusRemark { get; set; }
        public string Occupancy { get; set; }
        public int? LanguageStatusOk { get; set; }
        public int? LanguageStatusNotOk { get; set; }
        public string LanguageStatusRemark { get; set; }
        public int? TheaterInspectionStatusforMale { get; set; }
        public int? TheaterInspectionStatusforFemale { get; set; }
        public string TheaterInspectionforMale { get; set; }
        public string TheaterInspectionforFemale { get; set; }
        public string? AgentSelfie { get; set; }
        public int CreatedBy { get; set; }
    }
}
