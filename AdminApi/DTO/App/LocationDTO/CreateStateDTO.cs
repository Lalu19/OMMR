namespace AdminApi.DTO.App.LocationDTO
{
    public class CreateStateDTO
    {
        public string StateName { get; set; }
        public int CreatedBy { get; set; }
    }

    public class UpdateStateDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
