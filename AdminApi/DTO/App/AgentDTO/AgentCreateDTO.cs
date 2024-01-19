using System;

namespace AdminApi.DTO.App.AgentDTO
{
    public class AgentCreateDTO
    {
        public int StateId { get; set; }
        //public string Statename { get; set; }
        public string Cityname { get; set; }
        public string TheatreName { get; set; }
        public string AgentName { get; set; }
        public string Agentrole { get; set; }
        public string AgentPhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string ProfilePhoto { get; set; }
        public string AgentuserId { get; set; }
        public string PassWord { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class AgentUpdateDTO
    {
        public int StateId { get; set; }
        public int AgentId { get; set; }
        //public string Statename { get; set; }
        public string Cityname { get; set; }
        public string TheatreName { get; set; }
        public string AgentName { get; set; }
        public string Agentrole { get; set; }
        public string AgentPhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string ProfilePhoto { get; set; }
        public string AgentuserId { get; set; }
        public string PassWord { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
