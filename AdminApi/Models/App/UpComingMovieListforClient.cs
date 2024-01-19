using System;

namespace AdminApi.Models.App
{
    public class UpComingMovieListforClient
    {
        public int UpComingMovieListforClientId { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; }
        public string StarCast { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
