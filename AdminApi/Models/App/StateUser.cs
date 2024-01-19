using System;

namespace AdminApi.Models.App
{
    public class StateUser
    {
        public int StateUserId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public bool DeleteRequested { get; set; }
    }
}
