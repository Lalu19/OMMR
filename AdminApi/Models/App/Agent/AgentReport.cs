using System;

namespace AdminApi.Models.App.Agent
{
    public class AgentReport
    {
        public long AgentReportId { get; set; }
        public long StateId { get; set; }
        public long AgentId { get; set; }
        public string AgentName { get; set; }
        public string Agentrole { get; set; }
        public string TheatreName { get; set; }
        public string AgentPhoneNumber { get; set; }
        public string EmailId { get; set; }
        public bool TaskAccepted { get; set; }
        public bool TaskRejected { get; set; }
        public bool NotificationSent { get; set; }
        public DateTime? NotifiedOn { get; set; }
        public bool IsTimeExpired { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
