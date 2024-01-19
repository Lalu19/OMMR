namespace AdminApi.DTO.App
{
    public class PushNotificationDTO
    {
        public int? DeviceId { get; set; }
        public int AgentId { get; set; }
        public string FCMToken { get; set; }
        public string IMEINumber { get; set; }
        public int CreatedBy { get; set; }
    }

    public class UpdatePushNotificationDTO
    {
        public int PushNotificationId { get; set; }
        public int? DeviceId { get; set; }
        public int AgentId { get; set; }
        public string FCMToken { get; set; }
        public string? IMEINumber { get; set; }
       public int? UpdatedBy { get; set; }
    }
}
