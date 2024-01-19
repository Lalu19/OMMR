using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.DTO.App
{
    public class StateUserDTO
    {
        public int UserId { get; set; }
        public int StateId { get; set; }
        public int CreatedBy { get; set; }
    }
    public class UpdateStateUserDTO
    {
        public int StateUserId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
        public int? UpdatedBy { get; set; }
    }
    public class StateUserMasterDTO
    {
        public List<StateUserDTO> StateUserDTOs { get; set; }
    }
}
