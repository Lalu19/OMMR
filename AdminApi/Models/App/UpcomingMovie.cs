using System;

namespace AdminApi.Models.App
{
    public class UpcomingMovie
    {
        public int UpcomingMovieId { get; set; }
        public string MoviePoster { get; set; }
        public string TeaserLink { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
