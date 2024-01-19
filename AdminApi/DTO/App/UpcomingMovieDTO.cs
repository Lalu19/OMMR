namespace AdminApi.DTO.App
{
    public class UpcomingMovieDTO
    {
        public string MoviePoster { get; set; }
        public string TeaserLink { get; set; }
        public int CreatedBy { get; set; }
    }
    public class UpdateUpcomingMovieDTO
    {
        public int UpcomingMovieId { get; set; }
        public string MoviePoster { get; set; }
        public string TeaserLink { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
