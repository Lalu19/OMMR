using AdminApi.Models.Helper;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App.Location;
using AdminApi.DTO.App.LocationDTO;
using System;
using System.Linq;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : Controller
    {
      private readonly IConfiguration _config;
      private readonly AppDbContext _context;
      private readonly ISqlRepository<State> _StateRepo;

        public StateController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<State> StateRepo)
        {
            _config = config;
            _context = context;
            _StateRepo = StateRepo;
        }
        [HttpPost]
        public IActionResult StateCreate(CreateStateDTO createStateDTO) 
        {
            try
            {
                State state = new State();
                state.StateName = createStateDTO.StateName;
                state.CreatedBy = createStateDTO.CreatedBy;
                state.CreatedOn = System.DateTime.Now;
                var obj = _StateRepo.Insert(state);
                return Ok(obj);

            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetStateList()
        {
            try
            {
                var list = (from u in _context.States

                            select new { u.StateId, u.StateName, u.IsDeleted }).Where(x => x.IsDeleted == false).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Userid}")]
        public ActionResult GetStateListbyUserId(int Userid)
        {
            try
            {
                var list = (from u in _context.States

                            select new { u.StateId, u.StateName,u.CreatedBy, u.IsDeleted }).Where(x => x.IsDeleted == false && x.CreatedBy==Userid).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }
        //single Id
        [HttpGet("{StateId}")]
        public  ActionResult GetSingleState(int StateId)
        {
            try
            {
                var singleState = _StateRepo.SelectById(StateId);
                return Ok(singleState);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }
        //update
        [HttpPost]
        public ActionResult updateState(UpdateStateDTO updateStateDTO)
        {
            try
            {
                var objState = _context.States.SingleOrDefault(opt => opt.StateId == updateStateDTO.StateId);
                objState.StateName = updateStateDTO.StateName;
                objState.UpdatedBy = updateStateDTO.UpdatedBy;
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
                var objabout = _context.States.SingleOrDefault(opt => opt.StateId == Id);
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
