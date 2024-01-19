using AdminApi.Models.Helper;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App.Location;
using AdminApi.DTO.App.LocationDTO;
using System;
using System.Linq;
using AdminApi.Models.App;
using AdminApi.DTO.App;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateUserController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<StateUser> _StateUserRepo;

        public StateUserController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<StateUser> StateUserRepo)
        {
            _config = config;
            _context = context;
            _StateUserRepo = StateUserRepo;
        }

        //[HttpPost]
        //public IActionResult StateUserCreate(StateUserDTO stateUserDTO)
        //{
        //    var objCheck = _context.StateUser.SingleOrDefault(opt => opt.StateId == stateUserDTO.StateId && opt.IsDeleted == false);
        //    try
        //    {
        //      if(objCheck == null) {
        //        StateUser st = new StateUser();
        //        st.UserId = stateUserDTO.UserId;
        //        st.StateId = stateUserDTO.StateId;
        //        st.CreatedBy = stateUserDTO.CreatedBy;
        //        st.CreatedOn = System.DateTime.Now;
        //        var obj = _StateUserRepo.Insert(st);
        //        return Ok(obj);
        //      }
        //        else if (objCheck != null)
        //        {
        //            return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate State Name..!" });
        //        }
        //        return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpPost]
        //public IActionResult StateUserCreate(StateUserMasterDTO stateUserMasterDTO)
        //{

        //    try
        //    {
        //        for (int i = 0; i < stateUserMasterDTO.StateUserDTOs.Count; i++)
        //        {
        //            StateUser bed = new StateUser();
        //            bed.UserId = stateUserMasterDTO.StateUserDTOs[i].UserId;
        //            bed.StateId = stateUserMasterDTO.StateUserDTOs[i].StateId;
        //            bed.CreatedBy = stateUserMasterDTO.StateUserDTOs[i].CreatedBy;
        //            _StateUserRepo.Insert(bed);

        //        }

        //        return Ok(stateUserMasterDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult StateUserCreate(StateUserMasterDTO stateUserMasterDTO)
        {
            try
            {
                for (int i = 0; i < stateUserMasterDTO.StateUserDTOs.Count; i++)
                {
                    var objcheck = _context.StateUser.SingleOrDefault(opt => opt.StateId == stateUserMasterDTO.StateUserDTOs[i].StateId && opt.IsDeleted == false);

                    if (objcheck != null)
                    {
                        return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate State Name..!" });
                    }

                    StateUser bed = new StateUser();
                    bed.UserId = stateUserMasterDTO.StateUserDTOs[i].UserId;
                    bed.StateId = stateUserMasterDTO.StateUserDTOs[i].StateId;
                    bed.CreatedBy = stateUserMasterDTO.StateUserDTOs[i].CreatedBy;
                    _StateUserRepo.Insert(bed);
                }

                return Ok(stateUserMasterDTO);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult GetStateUserList()
        {
            try
            {
                var list = (from u in _context.StateUser
                            join p in _context.Users on u.UserId equals p.UserId

                            select new { 
                                u.StateUserId,
                                u.UserId,
                                p.FullName,
                                u.StateId,
                                u.IsDeleted 
                            }).Where(x => x.IsDeleted == false).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult StateUserList()
        {
            try
            {
                var list = (from u in _context.StateUser
                            join r in _context.Users on u.UserId equals r.UserId
                            join p in _context.States on u.StateId equals p.StateId

                            select new
                            {
                                u.StateUserId,
                                u.UserId,
                                r.FullName,
                                u.StateId,
                                p.StateName,
                                u.IsDeleted,
                                u.DeleteRequested
                            }).Where(x => x.IsDeleted == false && x.DeleteRequested==false).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //single Id
        [HttpGet("{stateUserId}")]
        public ActionResult GetSingleUser(int stateUserId)
        {
            try
            {
                var singleState = _StateUserRepo.SelectById(stateUserId);
                return Ok(singleState);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult updateStateUser(UpdateStateUserDTO updateStateUserDTO)
        {
            try
            {
                var objState = _context.StateUser.SingleOrDefault(opt => opt.StateUserId == updateStateUserDTO.StateUserId);
                objState.UserId = updateStateUserDTO.UserId;
                objState.StateId = updateStateUserDTO.StateId;
                objState.UpdatedBy = updateStateUserDTO.UpdatedBy;
                objState.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objState);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteState(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.StateUser.SingleOrDefault(opt => opt.StateUserId == Id);
                objabout.IsDeleted = true;
                objabout.UpdatedBy = DeletedBy;
                objabout.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objabout);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }
    }
}
