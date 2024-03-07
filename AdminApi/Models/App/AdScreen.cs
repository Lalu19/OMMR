using System;

namespace AdminApi.Models.App
{
    public class AdScreen
    {
        public int AdScreenId { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string TheatreName { get; set; }
        //public string Latitude { get; set; }
        //public string Longitude { get; set; }
        public string Screen { get; set; }
        public string AdsName { get; set; }
        public string AdsLanguage { get; set; }
        public string AdsSequence { get; set; }
        public string AdsDuration { get; set; }
        public string AdsPlaytime { get; set; }
        public string AdsYoutubeLink { get; set; }
        public string Media { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }       
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
