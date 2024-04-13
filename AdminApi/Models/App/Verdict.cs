using System;

namespace AdminApi.Models.App
{
    public class Verdict
    {
        public int VerdictId { get; set; }
        public string VerdictName { get; set; }
        public double VerdictValue { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
