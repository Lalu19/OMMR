using AdminApi.Models.App.Agent;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App;
using AdminApi.DTO.App.AgentDTO;
using AdminApi.Models.Helper;
using System.Linq;
using System;
using AdminApi.DTO.App;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HallPassController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<HallPass> _HallPassRepo;
        public HallPassController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<HallPass> HallPassRepo)

        {
            _config = config;
            _context = context;
            _HallPassRepo = HallPassRepo;

        }

        [HttpPost]
        public IActionResult HallPassCreate(HallPassDTO hallPassDTO)
        {
            var objcheck = _context.HallPass.SingleOrDefault(opt => opt.AdsName == hallPassDTO.AdsName && opt.Media == hallPassDTO.Media && opt.IsDeleted == false);
            try
            {
                if (objcheck == null)
                {
                    HallPass hp = new HallPass();
                    hp.AdsName = hallPassDTO.AdsName;
                    hp.Media = hallPassDTO.Media;
                    hp.HallPassImg = hallPassDTO.HallPassImg;
                    hp.CreatedBy = hallPassDTO.CreatedBy;
                    hp.CreatedOn = System.DateTime.Now;
                    var obj = _HallPassRepo.Insert(hp);
                    return Ok(obj);
                }
                else if (objcheck != null)
                {
                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate Ads Name..!" });
                }
                return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }

        }

        //[HttpPost]
        //public IActionResult HallPassCreate(HallPassDTO hallPassDTO)
        //{
        //    var objcheck = _context.HallPass.Where(opt => opt.IsDeleted == false).ToList();


        //    foreach (var hallPass in objcheck)
        //    {
        //        var theaterNames = hallPass.TheatreName.Split(',').Select(x => x.Trim()).ToList();
        //        var newTheatreNames = hallPassDTO.TheatreName.Split(',').Select(x => x.Trim()).ToList();


        //        foreach (var newTheatreName in newTheatreNames)
        //        {
        //            foreach (var theaterName in theaterNames)
        //            {
        //                if (theaterName.Equals(newTheatreName, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    return Accepted(new Confirmation { Status = "error", ResponseMsg = "Theater Name already exists!" });
        //                }
        //            }
        //        }
        //    }
        //    try
        //    {
        //        HallPass hp = new HallPass();
        //        hp.StateId = hallPassDTO.StateId;
        //        hp.Statename = hallPassDTO.Statename;
        //        hp.Cityname = hallPassDTO.Cityname;
        //        hp.TheatreName = hallPassDTO.TheatreName;
        //        hp.HallPassImg = hallPassDTO.HallPassImg;
        //        hp.CreatedBy = hallPassDTO.CreatedBy;
        //        hp.CreatedOn = System.DateTime.Now;
        //        var obj = _HallPassRepo.Insert(hp);
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet]
        public ActionResult GetHallPassList()
        {
            try
            {
                var list = (from u in _context.HallPass

                            select new
                            {
                                u.HallPassId,
                                u.AdsName,
                                u.Media,
                                u.HallPassImg,
                                u.CreatedBy,
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

        [HttpGet("{hallPassId}")]
        public ActionResult GetSingleAgent(int hallPassId)
        {
            try
            {
                var singleAgent = _HallPassRepo.SelectById(hallPassId);
                return Ok(singleAgent);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult UpdateHallPass(HallPassUpdateDTO hallPassUpdateDTO)
        {
            try
            {
                var objAgent = _context.HallPass.SingleOrDefault(opt => opt.HallPassId == hallPassUpdateDTO.HallPassId);
                objAgent.AdsName = hallPassUpdateDTO.AdsName;
                objAgent.Media = hallPassUpdateDTO.Media;
                objAgent.HallPassImg = hallPassUpdateDTO.HallPassImg;
                objAgent.UpdatedBy = hallPassUpdateDTO.UpdatedBy;
                objAgent.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objAgent);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteHallPass(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.HallPass.SingleOrDefault(opt => opt.HallPassId == Id);
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
