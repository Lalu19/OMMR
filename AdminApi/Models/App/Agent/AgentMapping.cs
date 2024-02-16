using System;

namespace AdminApi.Models.App.Agent
{
    public class AgentMapping
    {
        public int AgentMappingId { get; set; }
        public int StateId { get; set; }
        public int AgentId { get; set; }
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
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
