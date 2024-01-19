using System;

namespace AdminApi.Models.App
{
    public class ScreenList
    {
        public int ScreenListId { get; set; }
        public string Region { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string TheatreCode { get; set; }
        public string TheatreName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SEC { get; set; }
        public string Screen { get; set; }
        public string NoofSeats { get; set; }
        public string TheatreRating { get; set; }
        public string Rate { get; set; }
        public string Media { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
