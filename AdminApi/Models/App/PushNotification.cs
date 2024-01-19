using System;

namespace AdminApi.Models.App
{
    public class PushNotification
    {
        public int PushNotificationId { get; set; }
        public int? DeviceId { get; set; }
        public int AgentId { get; set; }
        public string FCMToken { get; set; }
        public string? IMEINumber { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
